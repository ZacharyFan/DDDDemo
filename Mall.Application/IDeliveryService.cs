using System.Collections.Generic;
using Mall.Application.DTO;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public interface IDeliveryService
    {
        List<ShippingAddressDTO> GetAllShippingAddresses(string userId);

        Result AddNewShippingAddress(string userId, DeliveryAddNewShippingAddressRequest request);

        Result EditShippingAddress(string userId, DeliveryEditShippingAddressRequest request);

        Result DeleteShippingAddress(string id);

        List<ExpressDTO> GetAllCanUseExpresses();
    }
}
