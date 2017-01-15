using System;
using System.Collections.Generic;
using Mall.Domain.DeliveryModule.Aggregate;
using Mall.Domain.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class ExpressSqlServerRepository : IExpressRepository
    {
        public string NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(Express aggregate)
        {
            throw new NotImplementedException();
        }

        public Express GetByIdentity(string identity)
        {
            throw new NotImplementedException();
        }

        public List<Express> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
