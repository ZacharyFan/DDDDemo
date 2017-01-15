using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Application.DTO;
using Mall.Domain;
using Mall.Domain.ValueObject;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public class DeliveryService : IDeliveryService
    {
        public List<ShippingAddressDTO> GetAllShippingAddresses(string userId)
        {
            var shippingAddresses = DomainRegistry.UserService().GetShippingAddressesByUserId(userId);
            return shippingAddresses.Select(ent => new ShippingAddressDTO
            {
                Address = ent.Address,
                CityId = ent.CityId,
                CityName = ent.CityName,
                CountryId = ent.CountryId,
                CountryName = ent.CountryName,
                DistrictId = ent.DistrictId,
                DistrictName = ent.DistrictName,
                Email = ent.Email,
                Mobile = ent.Mobile,
                Phone = ent.Phone,
                ProvinceId = ent.ProvinceId,
                ProvinceName = ent.ProvinceName,
                Receiver = ent.Receiver,
                ShippingAddressId = ent.ShippingAddressId
            }).ToList();
        }

        public Result AddNewShippingAddress(string userId, DeliveryAddNewShippingAddressRequest request)
        {
            var newAddress = ShippingAddress.NewOne(userId, request.Receiver, request.CountryId, request.CountryName,
                request.ProvinceId, request.ProvinceName, request.CityId, request.CityName, request.DistrictId,
                request.DistrictName, request.Address, request.Mobile, request.Phone, request.Email);
            DomainRegistry.UserService().AddNewShippingAddress(newAddress);
            return Result.Success();
        }

        public Result EditShippingAddress(string userId, DeliveryEditShippingAddressRequest request)
        {
            var newAddress = new ShippingAddress(request.ShippingAddressId, userId, request.Receiver, request.CountryId, request.CountryName, request.ProvinceId, request.ProvinceName, request.CityId, request.CityName, request.DistrictId,
                request.DistrictName, request.Address, request.Mobile, request.Phone, request.Email);
            DomainRegistry.UserService().EditShippingAddress(newAddress);
            return Result.Success();
        }

        public Result DeleteShippingAddress(string id)
        {
            DomainRegistry.UserService().DeleteShippingAddress(id);
            return Result.Success();
        }

        public List<ExpressDTO> GetAllCanUseExpresses()
        {
            var expresses = DomainRegistry.ExpressRepository().GetAll();
            return expresses.Select(ent => new ExpressDTO
            {
                Freight = ent.Freight,
                ID = ent.ID,
                Name = ent.Name
            }).ToList();
        }
    }
}
