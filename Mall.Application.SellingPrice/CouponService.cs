using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Application.SellingPrice.DTO;
using Mall.Domain.SellingPrice;
using Mall.Infrastructure.Results;

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

        public Result IsCouponCanUse(string id, DateTime orderTime)
        {
            var couponNo = DomainRegistry.CouponNoRepository().GetByIdentity(id);
            if (couponNo.IsUsed)
                return Result.Fail("对不起，该礼券已经被使用");

            var coupon = DomainRegistry.CouponRepository().GetByIdentity(couponNo.CouponId);
            if (coupon == null)
                return Result.Fail("对不起，该礼券已失效");

            if (coupon.ExpiryDate < orderTime)
                return Result.Fail("对不起，该礼券已经过期");

            return Result.Success();
        }

        public CouponDTO GetCoupon(string id)
        {
            var couponNo = DomainRegistry.CouponNoRepository().GetByIdentity(id);
            if (couponNo == null)
                return null;

            var coupon = DomainRegistry.CouponRepository().GetByIdentity(couponNo.CouponId);
            return new CouponDTO
            {
                CanUse = couponNo.IsUsed,
                ExpiryDate = coupon.ExpiryDate,
                ID = coupon.ID,
                Name = coupon.Name,
                Value = coupon.Value
            };
        }
    }
}
