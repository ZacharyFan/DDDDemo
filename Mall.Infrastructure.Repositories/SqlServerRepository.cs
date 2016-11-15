using System;
using Mall.Domain.Aggregate;
using Mall.Domain.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class SqlServerRepository : ICartRepository
    {
        public Guid NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid identity)
        {
            throw new NotImplementedException();
        }

        public Cart GetByIdentity(Guid identity)
        {
            throw new NotImplementedException();
        }

        public Cart GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
