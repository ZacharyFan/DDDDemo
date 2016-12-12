using System.Collections.Generic;
using System.Linq;
using Mall.Application.SellingPrice.DTO;
using Mall.Application.SellingPrice.Mapper;
using Mall.Domain;
using Mall.Domain.SellingPrice;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Mall.Domain.SellingPrice.Promotion.ValueObject;
using Mall.DomainService.SellingPrice;

namespace Mall.Application.SellingPrice
{
    public class CalculateSalePriceService : ICalculateSalePriceService
    {
        private static readonly MergeSingleProductPromotionForOneProductDomainService _mergeSingleProductPromotionForOneProductDomainService = new MergeSingleProductPromotionForOneProductDomainService();

        public CalculatedCartDTO Calculate(CartRequest cart)
        {
            List<BoughtProduct> boughtProducts = new List<BoughtProduct>();

            foreach (var cartItemRequest in cart.CartItems)
            {
                var promotionRules = DomainRegistry.PromotionRepository().GetListByContainsProductId(cartItemRequest.ProductId);
                var boughtProduct = new BoughtProduct(cartItemRequest.ProductId, cartItemRequest.Quantity, cartItemRequest.UnitPrice, 0, 0, promotionRules, cartItemRequest.SelectedMultiProductsPromotionId);
                boughtProducts.Add(boughtProduct);
            }

            #region 处理单品促销
            foreach (var boughtProduct in boughtProducts.ToList())
            {
                var calculateResult = _mergeSingleProductPromotionForOneProductDomainService.Merge(boughtProduct.ProductId, boughtProduct.DiscountedUnitPrice, boughtProduct.InSingleProductPromotionRules);

                var newBoughtProduct = boughtProduct.ChangeReducePrice(calculateResult);

                boughtProducts.Remove(boughtProduct);
                boughtProducts.Add(newBoughtProduct);
            }
            #endregion

            #region 处理多商品促销&构造DTO模型
            List<CalculatedFullGroupDTO> fullGroupDtos = new List<CalculatedFullGroupDTO>();
            foreach (var groupedPromotoinId in boughtProducts.Where(ent => ent.InMultiProductPromotionRule != null).GroupBy(ent => ((PromotionRule)ent.InMultiProductPromotionRule).PromotoinId))
            {
                var multiProdcutsReducePricePromotion = (IMultiProdcutsReducePricePromotion)groupedPromotoinId.First().InMultiProductPromotionRule;  //暂时只有减金额的多商品促销
                var products = groupedPromotoinId.ToList();

                if (multiProdcutsReducePricePromotion == null)
                    continue;

                var reducePrice = multiProdcutsReducePricePromotion.CalculateReducePrice(products);
                fullGroupDtos.Add(new CalculatedFullGroupDTO
                {
                    CalculatedCartItems = products.Select(ent => ent.ToDTO()).ToArray(),
                    ReducePrice = reducePrice,
                    MultiProductsPromotionId = groupedPromotoinId.Key
                });
            }
            #endregion

            #region 处理未参与满减的商品的会员价
            var noFullCartItems = boughtProducts.Where(ent => fullGroupDtos.SelectMany(e => e.CalculatedCartItems).All(e => e.ProductId != ent.ProductId)).ToList();
            var userRoleRelation = DomainRegistry.UserService().GetUserRoleRelation(cart.UserId);
            if (userRoleRelation != null)
            {
                var roleDiscountRelation = DomainRegistry.RoleDiscountRelationRepository().Get(userRoleRelation.RoleId);
                if (roleDiscountRelation != null)
                {
                    foreach (var boughtProduct in noFullCartItems.ToList())
                    {
                        var reducePriceByMemberPrice = roleDiscountRelation.CalculateDiscountedPrice(boughtProduct.DiscountedUnitPrice);
                        var newBoughtProduct = boughtProduct.ChangeReducePriceByMemberPrice(reducePriceByMemberPrice);

                        noFullCartItems.Remove(boughtProduct);
                        noFullCartItems.Add(newBoughtProduct);
                    }
                }
            }

            #endregion

            return new CalculatedCartDTO
            {
                CalculatedCartItems = noFullCartItems.Select(ent => ent.ToDTO()).ToArray(),
                CalculatedFullGroups = fullGroupDtos.ToArray(),
                CartId = cart.CartId
            };
        }
    }
}
