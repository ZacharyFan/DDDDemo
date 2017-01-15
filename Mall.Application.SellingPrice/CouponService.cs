using System.Collections.Generic;
using System.Linq;
using Mall.Application.SellingPrice.DTO;
using Mall.Domain.SellingPrice;

namespace Mall.Application.SellingPrice
{
    public class CouponService : ICouponService
    {
        public List<CouponDTO> Calculate(CartRequest cart)
        {
            var couponNos = DomainRegistry.CouponNoRepository().GetNotUsedByUserId(cart.UserId);

            var buyProductIds = cart.CartItems.Select(ent => ent.ProductId);
            List<CouponDTO> couponDtos = new List<CouponDTO>();
            foreach (var couponNo in couponNos)
            {
                if (couponNo.IsUsed)
                    continue;

                var coupon = DomainRegistry.CouponRepository().GetByIdentity(couponNo.CouponId);

                if (coupon.ContainsProductIds.Count == 0 || coupon.ContainsProductIds.Any(ent => buyProductIds.Any(e => e == ent)))
                {
                    couponDtos.Add(new CouponDTO
                    {
                        CanUse = couponNo.IsUsed,
                        ExpiryDate = coupon.ExpiryDate,
                        ID = couponNo.ID,
                        Name = coupon.Name,
                        Value = coupon.Value
                    });
                }
            }

            return couponDtos;
        }
    }
}
