using System;
using System.Linq;
using System.Reflection;
using Mall.Infrastructure.DomainEventCore;

namespace Mall.Domain.Order.DomainEvent
{
    public class DomainEventSubscriberConfiguration
    {
        public static void Initialize()
        {
            var types = Assembly.Load("Mall.Domain.Order.DomainEventSubscribers").GetTypes().Where(ent => !ent.IsGenericType && ent.GetInterface(typeof(IDomainEventSubscriber).FullName) != null).ToList();
            foreach (var type in types)
            {
                var subscriberInstance = Activator.CreateInstance(AppDomain.CurrentDomain, type.Assembly.FullName, type.FullName).Unwrap();
                var subscriber = (IDomainEventSubscriber)subscriberInstance;
                DomainEventBus.Instance().Subscribe(subscriber);
            }
        }
    }
}
