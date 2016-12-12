using System.Data;
using Mall.Domain.SellingPrice.MemberPrice.ValueObject;
using Mall.Infrastructure.ResponseHandle;

namespace Mall.Infrastructure.SellingPrice.Translators.User
{
    public class UserTranslator
    {
        public UserRoleRelation ToUserRoleRelation(string jsonData)
        {
            JsonResponseReader reader = new JsonResponseReader(jsonData);
            string userId = reader.GetString("userId");
            string roleId = reader.GetString("roleId");

            if (userId == null)
                throw new NoNullAllowedException("未能正常解析用户ID");

            if (roleId == null)
                throw new NoNullAllowedException("未能正常解析等级ID");

            var user = new UserRoleRelation(userId, roleId);
            return user;
        }
    }
}
