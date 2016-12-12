using System;
using Mall.Domain.ValueObject;

namespace Mall.Domain.IRemoteServices
{
    public interface IUserService
    {
        User GetUser(string userId);
    }
}
