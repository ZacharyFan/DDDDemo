using System.Collections.Generic;
using Mall.Domain.DeliveryModule.Aggregate;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.IRepositories
{
    public interface IExpressRepository : IRepository<Express>
    {
        List<Express> GetAll();
    }
}
