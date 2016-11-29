using System;

namespace Mall.Infrastructure.DomainCore
{
    public interface IRepository<T> where T : Aggregate
    {
        string NextIdentity();

        void Save(T aggregate);

        void Remove(string identity);

        T GetByIdentity(string identity);
    }
}
