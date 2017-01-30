using Mall.Domain.Order.DomainEvent.Events;
using Mall.Infrastructure.DomainEventCore;

namespace Mall.Domain.Order.DomainEventSubscribers
{
    public class OrderCreatedSubscriberSellingPriceContext : DomainEventSubscriber<OrderCreated>
    {
        public override void HandleEvent(OrderCreated domainEvent)
        {
            //TODO anything
            throw new System.NotImplementedException();
        }
    }
}
