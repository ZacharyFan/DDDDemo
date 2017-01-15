using System;

namespace Mall.Application.DTO
{
    public class CouponDTO
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public bool CanUse { get; set; }

        public decimal Value { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
