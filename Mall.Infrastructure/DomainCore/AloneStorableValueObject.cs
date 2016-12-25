namespace Mall.Infrastructure.DomainCore
{
    /// <summary>
    /// 表示一个可独立持久化的值对象
    /// </summary>
    public abstract class AloneStorableValueObject : DelegateIdentifier, IAloneStorable
    {
    }
}
