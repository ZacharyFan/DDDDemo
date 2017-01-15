using System.Collections.Generic;
using System.Linq;
using Mall.Application.SellingPrice;
using Mall.Application.SellingPrice.DTO;
using Mall.Domain.CartModule.Aggregate;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.SellingPrice
{
    public class SellingPriceAdapter
    {
        private static readonly SellingPriceTranslator _sellingPriceTranslator = new SellingPriceTranslator();
        private static readonly ICalculateSalePriceService _calculateSalePriceService = new CalculateSalePriceService();
        private static readonly ICouponService _couponService = new CouponService();

        public SellingPriceCart Calculate(Cart cart)
        {
            var dto = _calculateSalePriceService.Calculate(ToRequest(cart));
            return _sellingPriceTranslator.ToSellingPriceCart(dto);
        }

        public List<Coupon> CalculateAllCoupons(Cart cart)
        {
            var couponDtos = _couponService.Calculate(ToRequest(cart));
            return _sellingPriceTranslator.ToCoupons(couponDtos);
        }

        private CartRequest ToRequest(Cart cart)
        {
            return new CartRequest
            {
                CartItems = cart.GetCartItems().Select(ent => new CartItemRequest
                {
                    ProductId = ent.ID,
                    Quantity = ent.Quantity,
                    UnitPrice = ent.UnitPrice,
                    SelectedMultiProductsPromotionId = ent.SelectedMultiProductsPromotionId
                }).ToArray(),
                CartId = cart.ID,
                UserId = cart.UserId
            };
        }
    }
}
