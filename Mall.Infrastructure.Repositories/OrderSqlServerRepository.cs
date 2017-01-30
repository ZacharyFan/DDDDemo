using System;
using Mall.Domain.Order.Aggregate;
using Mall.Domain.Order.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class OrderSqlServerRepository : IOrderRepository
    {
        public string NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(Order aggregate)
        {
            throw new NotImplementedException();
        }

        public Order GetByIdentity(string identity)
        {
            throw new NotImplementedException();
        }
    }
}
