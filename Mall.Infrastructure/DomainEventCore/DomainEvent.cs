using System;

namespace Mall.Infrastructure.DomainEventCore
{
    public abstract class DomainEvent : Infrastructure.DomainCore.AggregateRoot, IDomainEvent
    {
        public readonly DateTime OccurredOnTime;

        protected DomainEvent()
        {
            this.ID = Guid.NewGuid().ToString();
            this.OccurredOnTime = DateTime.Now;
            this.IsRead = false;
        }

        public DateTime OccurredOn()
        {
            return this.OccurredOnTime;
        }

        public void Read()
        {
            this.IsRead = true;
        }

        public bool IsRead { get; private set; }
    }
}
