namespace Mall.Infrastructure.DomainCore
{
    /// <summary>
    /// 表示所有集成于该接口的类型都是Unit Of Work的一种实现。
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获得一个<see cref="System.Boolean"/>值，该值表述了当前的Unit Of Work事务是否已被提交。
        /// </summary>
        bool Committed { get; }

        /// <summary>
        /// 提交当前的Unit Of Work事务。
        /// </summary>
        bool Commit();

        /// <summary>
        /// 回滚当前的Unit Of Work事务。
        /// </summary>
        void Rollback();

        TRepositoryItem LockObject<TRepositoryItem>(TRepositoryItem obj)
            where TRepositoryItem : AggregateRoot;

        void RegisterSaved<TRepositoryItem>(TRepositoryItem obj)
            where TRepositoryItem : AggregateRoot;

        void RegisterRemoved<TRepositoryItem>(TRepositoryItem obj)
            where TRepositoryItem : AggregateRoot;
    }
}
