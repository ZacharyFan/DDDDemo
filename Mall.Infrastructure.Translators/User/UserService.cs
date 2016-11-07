using System;
using System.IO;
using System.Net;
using Mall.Domain.IRemoteServices;

namespace Mall.Infrastructure.Translators.User
{
    public class UserService : IUserService
    {
        private static readonly UserAdapter _userAdapter = new UserAdapter();

        public Domain.ValueObject.User GetUser(Guid userId)
        {
            return _userAdapter.GetUser(userId);
        }
    }
}
