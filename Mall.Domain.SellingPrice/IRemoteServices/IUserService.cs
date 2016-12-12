using Mall.Domain.SellingPrice.MemberPrice.ValueObject;

namespace Mall.Domain.SellingPrice.IRemoteServices
{
    public interface IUserService
    {
        UserRoleRelation GetUserRoleRelation(string userId);
    }
}
