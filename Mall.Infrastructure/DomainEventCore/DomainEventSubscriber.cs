using System;

namespace Mall.Infrastructure.DomainEventCore
{
    public abstract class DomainEventSubscriber<T> : IDomainEventSubscriber where T : IDomainEvent
    {
        /// <summary>订阅的事件类型
        /// </summary>
        /// <returns></returns>
        public Type SubscribedToEventType()
        {
            return typeof(T);
        }

        public abstract void HandleEvent(T domainEvent);

        public void Handle(object domainEvent)
        {
            if (domainEvent is T)
            {
                this.HandleEvent((T)domainEvent);
            }
            else
            {
                throw new NotSupportedException(string.Format("当前订阅者支持的事件类型是：{0}，当前事件是：{1}", typeof(T).FullName, domainEvent.GetType().FullName));
            }
        }
    }
}
