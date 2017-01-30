using System;

namespace Mall.Infrastructure.DomainEventCore
{
    public interface IDomainEvent
    {
        DateTime OccurredOn();

        /// <summary>
        /// 设置为已读
        /// </summary>
        /// <returns></returns>
        void Read();

        /// <summary>
        /// 是否已读
        /// </summary>
        bool IsRead { get; }
    }
}
