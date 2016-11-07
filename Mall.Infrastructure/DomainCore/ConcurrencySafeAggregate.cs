namespace Mall.Infrastructure.DomainCore
{
    /// <summary>
    /// 标识继承该类的是一个需要保证线程安全的聚合
    /// </summary>
    public class ConcurrencySafeAggregate : ConcurrencySafeEntity
    {
    }
}
