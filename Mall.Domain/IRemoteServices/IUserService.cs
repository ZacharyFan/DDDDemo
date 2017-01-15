using System;
using System.Collections.Generic;
using Mall.Domain.ValueObject;

namespace Mall.Domain.IRemoteServices
{
    public interface IUserService
    {
        User GetUser(string userId);

        List<ShippingAddress> GetShippingAddressesByUserId(string userId);

        void AddNewShippingAddress(ShippingAddress newAddress);

        void EditShippingAddress(ShippingAddress editAddress);

        void DeleteShippingAddress(string id);
    }
}
