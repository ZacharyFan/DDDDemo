namespace Mall.Infrastructure.DomainCore
{
    /// <summary>
    /// 标识继承该类的是拥有一个委派标识的值对象
    /// </summary>
    public abstract class IdentityValueObject
    {
        /// <summary>
        /// 委派标识
        /// </summary>
        protected string Identity { get; set; }
    }
}
