using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mall.Domain.SellingPrice.Promotion.Aggregate;

namespace Mall.Domain.SellingPrice.Promotion.ValueObject
{
    public class BoughtProduct : Infrastructure.DomainCore.ValueObject
    {
        private readonly List<PromotionRule> _promotionRules = new List<PromotionRule>();

        public string ProductId { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal ReducePrice { get; private set; }

        public decimal ReducePriceByMemberPrice { get; private set; }

        /// <summary>
        /// 商品在优惠后的单价，如果没有优惠则为正常购买的单价（暂时包含单品优惠、会员价）
        /// </summary>
        public decimal DiscountedUnitPrice
        {
            get { return UnitPrice - ReducePrice - ReducePriceByMemberPrice; }
        }

        public decimal TotalDiscountedPrice
        {
            get { return DiscountedUnitPrice * Quantity; }
        }

        public ReadOnlyCollection<ISingleProductPromotion> InSingleProductPromotionRules
        {
            get { return _promotionRules.OfType<ISingleProductPromotion>().ToList().AsReadOnly(); }
        }

        public IMultiProductsPromotion InMultiProductPromotionRule { get; private set; }

        public BoughtProduct(string productId, int quantity, decimal unitPrice, decimal reducePrice, decimal reducePriceByMemberPrice, IEnumerable<PromotionRule> promotionRules, string selectedMultiProdcutsPromotionId)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("productId不能为null或者空字符串", "productId");

            if (quantity <= 0)
                throw new ArgumentException("quantity不能小于等于0", "quantity");

            if (unitPrice < 0)
                throw new ArgumentException("unitPrice不能小于0", "unitPrice");

            if (reducePrice < 0)
                throw new ArgumentException("reducePrice不能小于0", "reducePrice");

            if (reducePriceByMemberPrice < 0)
                throw new ArgumentException("reducePriceByMemberPrice不能小于0", "reducePriceByMemberPrice");

            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.ReducePrice = reducePrice;
            this.ReducePriceByMemberPrice = reducePriceByMemberPrice;

            if (promotionRules != null)
            {
                this._promotionRules.AddRange(promotionRules);
                var multiProductsPromotions = this._promotionRules.OfType<IMultiProductsPromotion>().ToList();
                if (multiProductsPromotions.Count > 0)
                {
                    var selectedMultiProductsPromotionRule = multiProductsPromotions.SingleOrDefault(ent => ((PromotionRule)ent).PromotoinId == selectedMultiProdcutsPromotionId);

                    InMultiProductPromotionRule = selectedMultiProductsPromotionRule ?? multiProductsPromotions.First();
                }
            }
        }

        public BoughtProduct ChangeReducePrice(decimal reducePrice)
        {
            if (reducePrice < 0)
                throw new ArgumentException("reducePrice不能小于0");

            if (reducePrice > this.UnitPrice)
                throw new ArgumentOutOfRangeException("reducePrice", "reducePrice不能大于UnitPrice");

            var selectedMultiProdcutsPromotionId = this.InMultiProductPromotionRule == null
                ? null
                : ((PromotionRule)this.InMultiProductPromotionRule).PromotoinId;
            return new BoughtProduct(this.ProductId, this.Quantity, this.UnitPrice, reducePrice, this.ReducePriceByMemberPrice, this._promotionRules, selectedMultiProdcutsPromotionId);
        }

        public BoughtProduct ChangeReducePriceByMemberPrice(decimal reducePriceByMemberPrice)
        {
            if (reducePriceByMemberPrice < 0)
                throw new ArgumentException("reducePriceByMemberPrice不能小于0");

            if (reducePriceByMemberPrice > this.UnitPrice)
                throw new ArgumentOutOfRangeException("reducePriceByMemberPrice", "reducePriceByMemberPrice不能大于UnitPrice");

            var selectedMultiProdcutsPromotionId = this.InMultiProductPromotionRule == null
                ? null
                : ((PromotionRule)this.InMultiProductPromotionRule).PromotoinId;
            return new BoughtProduct(this.ProductId, this.Quantity, this.UnitPrice, this.ReducePrice, reducePriceByMemberPrice, this._promotionRules, selectedMultiProdcutsPromotionId);
        }
    }
}
