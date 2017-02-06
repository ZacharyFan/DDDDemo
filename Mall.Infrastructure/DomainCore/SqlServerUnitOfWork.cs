using System;

namespace Mall.Infrastructure.DomainCore
{
    public class SqlServerUnitOfWork : UnitOfWork
    {
        public override bool Commit()
        {
            throw new NotImplementedException();
        }

        public override void Rollback()
        {
            throw new NotImplementedException();
        }

        public override TRepositoryItem LockObject<TRepositoryItem>(TRepositoryItem obj)
        {
            throw new NotImplementedException();
        }
    }
}
