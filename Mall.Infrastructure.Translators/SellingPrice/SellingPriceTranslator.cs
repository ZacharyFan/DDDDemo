using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Application.SellingPrice.DTO;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.SellingPrice
{
    public class SellingPriceTranslator
    {
        public SellingPriceCart ToSellingPriceCart(CalculatedCartDTO cartDTO)
        {
            var fullGroups = cartDTO.CalculatedFullGroups.Select(ToSellingPriceFullGroup);
            var cartItems = cartDTO.CalculatedCartItems.Select(ToSellingPriceCartItem);
            return new SellingPriceCart(cartDTO.CartId, fullGroups, cartItems);
        }

        private SellingPriceFullGroup ToSellingPriceFullGroup(CalculatedFullGroupDTO dto)
        {
            return new SellingPriceFullGroup(dto.CalculatedCartItems.Select(ToSellingPriceCartItem), dto.ReducePrice, dto.MultiProductsPromotionId);
        }

        private SellingPriceCartItem ToSellingPriceCartItem(CalculatedCartItemDTO dto)
        {
            return new SellingPriceCartItem(dto.ProductId, dto.ReducePrice);
        }

        public List<Coupon> ToCoupons(IEnumerable<CouponDTO> coupons)
        {
            if (coupons == null)
                return null;
            return coupons.Select(ent => new Coupon(ent.ID, ent.Name, ent.CanUse, ent.Value, ent.ExpiryDate)).ToList();
        }

        public Coupon ToCoupon(CouponDTO coupon)
        {
            if (coupon == null)
                throw new ArgumentNullException("coupon");
            return new Coupon(coupon.ID, coupon.Name, coupon.CanUse, coupon.Value, coupon.ExpiryDate);
        }
    }
}
