namespace Mall.Infrastructure.DomainCore
{
    /// <summary>
    /// 标识继承该类的是一个需要保证线程安全的实体
    /// </summary>
    public class ConcurrencySafeEntity : Entity
    {
        /// <summary>
        /// 乐观并发的版本号
        /// </summary>
        protected int VersionNo { get; set; }
    }
}
