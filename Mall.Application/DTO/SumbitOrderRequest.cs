namespace Mall.Application.DTO
{
    public class SumbitOrderRequest
    {
        public string UserId { get; set; }

        public string ShippingAddressId { get; set; }

        public string PaymentMethodId { get; set; }

        public string ExpressId { get; set; }

        public string CouponId { get; set; }
    }
}
