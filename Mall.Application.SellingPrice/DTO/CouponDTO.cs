using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mall.Application.SellingPrice.DTO
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
