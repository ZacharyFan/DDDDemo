using System.Collections.Generic;
using Mall.Domain.IRemoteServices;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.User
{
    public class UserService : IUserService
    {
        private static readonly UserAdapter _userAdapter = new UserAdapter();

        public Domain.ValueObject.User GetUser(string userId)
        {
            return _userAdapter.GetUser(userId);
        }

        public List<ShippingAddress> GetShippingAddressesByUserId(string userId)
        {
            return _userAdapter.GetShippingAddressesByUserId(userId);
        }

        public void AddNewShippingAddress(ShippingAddress newAddress)
        {
            _userAdapter.AddNewShippingAddress(newAddress);
        }

        public void EditShippingAddress(ShippingAddress editAddress)
        {
            _userAdapter.EditShippingAddress(editAddress);
        }

        public void DeleteShippingAddress(string id)
        {
            _userAdapter.DeleteShippingAddress(id);
        }
    }
}
