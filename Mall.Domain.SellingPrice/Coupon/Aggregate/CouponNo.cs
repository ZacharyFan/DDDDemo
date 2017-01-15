using System;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.SellingPrice.Coupon.Aggregate
{
    public class CouponNo : AggregateRoot
    {
        public string CouponId { get; private set; }

        public DateTime UsedTime { get; private set; }

        public bool IsUsed
        {
            get { return UsedTime != default(DateTime) && UsedTime < DateTime.Now; }
        }

        public string UserId { get; private set; }

        public CouponNo(string couponId, DateTime usedTime, string userId)
        {
            if (string.IsNullOrWhiteSpace(couponId))
                throw new ArgumentNullException("couponId");

            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            this.CouponId = couponId;
            this.UsedTime = usedTime;
            this.UserId = userId;
        }

        public void BeUsed()
        {
            this.UsedTime = DateTime.Now;
        }
    }
}
