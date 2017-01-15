using System;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.DeliveryModule.Aggregate
{
    public class Express : AggregateRoot
    {
        public string Name { get; private set; }

        public decimal Freight { get; private set; }

        public Express(string id, string name, decimal freight)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (freight < 0)
                throw new ArgumentException("freight不能小于0");

            this.ID = id;
            this.Name = name;
            this.Freight = freight;
        }
    }
}
