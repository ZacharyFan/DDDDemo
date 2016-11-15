using System;

namespace Mall.Infrastructure.DomainCore
{
    public interface IRepository<T> where T : Aggregate
    {
        Guid NextIdentity();

        void Save(T aggregate);

        void Remove(Guid identity);

        T GetByIdentity(Guid identity);
    }
}
