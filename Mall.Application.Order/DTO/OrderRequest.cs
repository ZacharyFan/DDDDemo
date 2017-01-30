using System;

namespace Mall.Application.Order.DTO
{
    public class OrderRequest
    {
        public string CartId { get; set; }

        public string UserId { get; set; }

        public string Receiver { get; set; }

        public string CountryId { get; set; }

        public string CountryName { get; set; }

        public string ProvinceId { get; set; }

        public string ProvinceName { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public string DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string PaymentMethodId { get; set; }

        public string PaymentMethodName { get; set; }

        public string ExpressId { get; set; }

        public string ExpressName { get; set; }

        public decimal Freight { get; set; }

        public string CouponId { get; set; }

        public string CouponName { get; set; }

        public decimal CouponValue { get; set; }

        public DateTime OrderTime { get; set; }

        public OrderItemRequest[] OrderItems { get; set; }
    }
}
