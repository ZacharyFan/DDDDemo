using System;

namespace Mall.Domain.ValueObject
{
    public class ShippingAddress : Infrastructure.DomainCore.ValueObject
    {
        public string ShippingAddressId { get; private set; }

        public string UserId { get; private set; }

        public string Receiver { get; private set; }

        public string CountryId { get; private set; }

        public string CountryName { get; private set; }

        public string ProvinceId { get; private set; }

        public string ProvinceName { get; private set; }

        public string CityId { get; private set; }

        public string CityName { get; private set; }

        public string DistrictId { get; private set; }

        public string DistrictName { get; private set; }

        public string Address { get; private set; }

        public string Mobile { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public ShippingAddress(string shippingAddressId, string userId, string receiver, string countryId,
            string countryName, string provinceId, string provinceName, string cityId, string cityName,
            string districtId, string districtName, string address, string mobile, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(shippingAddressId))
                throw new ArgumentNullException("shippingAddressId");

            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            if (string.IsNullOrWhiteSpace(receiver))
                throw new ArgumentNullException("receiver");

            if (string.IsNullOrWhiteSpace(countryId))
                throw new ArgumentNullException("countryId");

            if (string.IsNullOrWhiteSpace(countryName))
                throw new ArgumentNullException("countryName");

            if (string.IsNullOrWhiteSpace(provinceId))
                throw new ArgumentNullException("provinceId");

            if (string.IsNullOrWhiteSpace(provinceName))
                throw new ArgumentNullException("provinceName");

            if (string.IsNullOrWhiteSpace(cityId))
                throw new ArgumentNullException("cityId");

            if (string.IsNullOrWhiteSpace(cityName))
                throw new ArgumentNullException("cityName");

            if (string.IsNullOrWhiteSpace(districtId))
                throw new ArgumentNullException("districtId");

            if (string.IsNullOrWhiteSpace(districtName))
                throw new ArgumentNullException("districtName");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address");

            if (string.IsNullOrWhiteSpace(mobile))
                throw new ArgumentNullException("mobile");

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException("phone");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("email");

            this.ShippingAddressId = shippingAddressId;
            this.UserId = userId;
            this.Receiver = receiver;
            this.CountryId = countryId;
            this.CountryName = countryName;
            this.ProvinceId = provinceId;
            this.ProvinceName = provinceName;
            this.CityId = cityId;
            this.CityName = cityName;
            this.DistrictId = districtId;
            this.DistrictName = districtName;
            this.Address = address;
            this.Mobile = mobile;
            this.Phone = phone;
            this.Email = email;
        }

        public static ShippingAddress NewOne(string userId, string receiver, string countryId,
            string countryName, string provinceId, string provinceName, string cityId, string cityName,
            string districtId, string districtName, string address, string mobile, string phone, string email)
        {
            return new ShippingAddress(Guid.NewGuid().ToString(), userId, receiver, countryId, countryName, provinceId,
                provinceName, cityId, cityName, districtId, districtName, address, mobile, phone, email);
        }
    }
}
