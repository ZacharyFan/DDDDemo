using System;
using Mall.Domain.Aggregate;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.IRepositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetByUserId(Guid userId);
    }
}
