using System;
using Mall.Domain.Order.DomainEvent.Events;
using Mall.Infrastructure.DomainEventCore;

namespace Mall.Domain.Order.DomainEventSubscribers
{
    public class OrderCreatedSubscriberPaymentContext : DomainEventSubscriber<OrderCreated>
    {
        public override void HandleEvent(OrderCreated domainEvent)
        {
            //TODO anything

            throw new NotImplementedException();
        }
    }
}
