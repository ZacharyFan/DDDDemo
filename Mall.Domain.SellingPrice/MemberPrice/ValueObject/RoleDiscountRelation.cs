using System;

namespace Mall.Domain.SellingPrice.MemberPrice.ValueObject
{
    public class RoleDiscountRelation
    {
        public string RoleId { get; private set; }

        public float DiscountRate { get; private set; }

        public RoleDiscountRelation(string roleId, float discountRate)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                throw new ArgumentNullException("roleId");

            if (discountRate < 0)
                throw new ArgumentException("discountRate");

            this.RoleId = roleId;
            this.DiscountRate = discountRate;
        }
    }
}
