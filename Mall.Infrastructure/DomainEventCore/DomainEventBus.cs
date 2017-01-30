using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Mall.Infrastructure.DomainEventCore
{
    public class DomainEventBus
    {
        public delegate void DistributeExceptionHandle(IDomainEventSubscriber subscriber, IDomainEvent domainEvent, Exception exception);
        /// <summary>
        /// Key:DomainEvent的类型，Value订阅该类型事件的订阅者列表
        /// </summary>
        private static readonly Dictionary<Type, List<IDomainEventSubscriber>> _subscribers = new Dictionary<Type, List<IDomainEventSubscriber>>();

        private static readonly object _lockObj = new object();

        public event DistributeExceptionHandle DistributeExceptionEvent;

        private static DomainEventBus _instance;
        public static DomainEventBus Instance()
        {
            if (_instance != null)
                return _instance;
            var temp = new DomainEventBus();
            Interlocked.CompareExchange(ref _instance, temp, null);
            return temp;
        }

        public void Publish<T>(T aDomainEvent) where T : IDomainEvent
        {
            if (aDomainEvent.IsRead)
                return;

            var registeredSubscribers = _subscribers;
            if (registeredSubscribers != null)
            {
                var domainEventType = aDomainEvent.GetType();
                List<IDomainEventSubscriber> subscribers;
                if (!registeredSubscribers.TryGetValue(domainEventType, out subscribers))
                {
                    aDomainEvent.Read();  //未找到订阅者，但是消息还是消费掉。
                    return;
                }

                foreach (var domainEventSubscriber in subscribers)
                {
                    var subscribedTo = domainEventSubscriber.SubscribedToEventType();
                    if (subscribedTo == domainEventType || subscribedTo is IDomainEvent)
                    {
                        Distribute(domainEventSubscriber, aDomainEvent);
                    }
                }

                aDomainEvent.Read();
            }
        }

        private void Distribute(IDomainEventSubscriber subscriber, IDomainEvent domainEvent)
        {
            try
            {
                subscriber.Handle(domainEvent);
            }
            catch (Exception ex)
            {
                OnDistributeExceptionEvent(subscriber, domainEvent, ex);
            }
        }

        public void Subscribe(IDomainEventSubscriber aSubscriber)
        {
            lock (_lockObj)
            {
                var registeredSubscribers = _subscribers;

                var domainEventType = aSubscriber.SubscribedToEventType();
                List<IDomainEventSubscriber> subscribers;

                if (!registeredSubscribers.TryGetValue(domainEventType, out subscribers))
                {
                    subscribers = new List<IDomainEventSubscriber>();
                    registeredSubscribers.Add(domainEventType, subscribers);
                }

                if (subscribers.Any(ent => ent.SubscribedToEventType().FullName == aSubscriber.SubscribedToEventType().FullName && ent.GetType().FullName == aSubscriber.GetType().FullName))  //相同的订阅只接收一次。
                    return;

                subscribers.Add(aSubscriber);
            }
        }

        protected virtual void OnDistributeExceptionEvent(IDomainEventSubscriber subscriber, IDomainEvent domainEvent, Exception exception)
        {
            var handler = DistributeExceptionEvent;
            if (handler != null)
                handler(subscriber, domainEvent, exception);
        }
    }
}

