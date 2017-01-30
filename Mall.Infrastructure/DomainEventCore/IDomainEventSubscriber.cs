using System;

namespace Mall.Infrastructure.DomainEventCore
{
    public interface IDomainEventSubscriber
    {
        Type SubscribedToEventType();

        void Handle(object domainEvent);
    }
}
