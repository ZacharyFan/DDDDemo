namespace Mall.Infrastructure.DomainCore
{
    /// <summary>
    /// 表示继承该类的是一个实体
    /// </summary>
    public abstract class Entity : DelegateIdentifier
    {
        public string ID
        {
            get { return this.Identity; }
            protected set { this.Identity = value; }
        }
    }
}
