using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.SellingPrice.Coupon.Aggregate
{
    public class Coupon : AggregateRoot
    {
        public string Name { get; private set; }

        public decimal Value { get; private set; }

        public DateTime ExpiryDate { get; private set; }
        
        public List<string> ContainsProductIds { get; private set; }

        public Coupon(string name, decimal value, DateTime expiryDate, IEnumerable<string> containsProductIds)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (value <= 0)
                throw new ArgumentException("value不能小于等于0", "value");

            if (expiryDate == default(DateTime))
                throw new ArgumentException("请传入正确的expiryDate", "expiryDate");

            if (containsProductIds == null)
                throw new ArgumentNullException("containsProductIds");

            this.Name = name;
            this.Value = value;
            this.ExpiryDate = expiryDate;
            this.ContainsProductIds = containsProductIds.ToList();
        }
    }
}
