using System;

namespace Mall.Domain.SellingPrice.MemberPrice.ValueObject
{
    public class RoleDiscountRelation : Infrastructure.DomainCore.ValueObject
    {
        public string RoleId { get; private set; }

        public string RoleName { get; private set; }

        public float DiscountRate { get; private set; }

        public RoleDiscountRelation(string roleId, string roleName, float discountRate)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                throw new ArgumentNullException("roleId");

            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException("roleName");

            if (discountRate < 0)
                throw new ArgumentException("discountRate");

            this.RoleId = roleId;
            this.RoleName = roleName;
            this.DiscountRate = discountRate;
        }

        public decimal CalculateDiscountedPrice(decimal price)
        {
            return price - price * Convert.ToDecimal(this.DiscountRate);
        }
    }
}
