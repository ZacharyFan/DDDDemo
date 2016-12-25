namespace Mall.Infrastructure.DomainCore
{
    /// <summary>
    /// 表示继承该类的是拥有一个唯一标识的对象
    /// </summary>
    public abstract class DelegateIdentifier
    {
        /// <summary>
        /// 委派标识
        /// </summary>
        protected string Identity { get; set; }
    }
}
