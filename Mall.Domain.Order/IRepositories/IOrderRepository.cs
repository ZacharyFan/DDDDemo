using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.Order.IRepositories
{
    public interface IOrderRepository : IRepository<Aggregate.Order>
    {
    }
}
