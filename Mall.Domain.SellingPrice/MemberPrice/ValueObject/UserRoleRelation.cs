using System;

namespace Mall.Domain.SellingPrice.MemberPrice.ValueObject
{
    public class UserRoleRelation : Infrastructure.DomainCore.ValueObject
    {
        public string UserId { get; private set; }

        public string RoleId { get; private set; }

        public UserRoleRelation(string userId, string roleId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            if (string.IsNullOrWhiteSpace(roleId))
                throw new ArgumentNullException("roleId");

            this.UserId = userId;
            this.RoleId = roleId;
        }
    }
}
