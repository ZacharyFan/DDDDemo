using System;
using Mall.Domain.Aggregate;
using Mall.Domain.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class CartSqlServerRepository : ICartRepository
    {
        public string NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void Remove(string identity)
        {
            throw new NotImplementedException();
        }

        public Cart GetByIdentity(string identity)
        {
            throw new NotImplementedException();
        }

        public Cart GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
