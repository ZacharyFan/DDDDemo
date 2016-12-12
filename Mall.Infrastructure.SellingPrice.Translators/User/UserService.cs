using Mall.Domain.SellingPrice.IRemoteServices;
using Mall.Domain.SellingPrice.MemberPrice.ValueObject;

namespace Mall.Infrastructure.SellingPrice.Translators.User
{
    public class UserService : IUserService
    {
        private static readonly UserAdapter _userAdapter = new UserAdapter();

        public UserRoleRelation GetUserRoleRelation(string userId)
        {
            return _userAdapter.GetUserRoleRelation(userId);
        }
    }
}
