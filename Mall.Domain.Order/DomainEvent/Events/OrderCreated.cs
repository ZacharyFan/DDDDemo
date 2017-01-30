namespace Mall.Domain.Order.DomainEvent.Events
{
    public class OrderCreated : Infrastructure.DomainEventCore.DomainEvent
    {
        public string OrderId { get; private set; }

        public string UserId { get; private set; }

        public string Receiver { get; private set; }

        public OrderCreated(string orderId, string userId, string receiver)
        {
            this.OrderId = orderId;
            this.UserId = userId;
            this.Receiver = receiver;
        }
    }
}
