namespace Mall.Application.DTO
{
    public class DeliveryAddNewShippingAddressRequest
    {
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
    }
}
