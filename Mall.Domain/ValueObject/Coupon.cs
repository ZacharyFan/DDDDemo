using System;

namespace Mall.Domain.ValueObject
{
    public class Coupon : Infrastructure.DomainCore.ValueObject
    {
        public string ID { get; private set; }

        public string Name { get; private set; }

        public bool CanUse { get; private set; }

        public decimal Value { get; private set; }

        public DateTime ExpiryDate { get; private set; }

        public Coupon(string id, string name, bool canUse, decimal value, DateTime expiryDate)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            this.ID = id;
            this.Name = name;
            this.CanUse = canUse;
            this.Value = value;
            this.ExpiryDate = expiryDate;
        }
    }
}
