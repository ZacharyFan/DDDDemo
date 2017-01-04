using System;
using Mall.Domain.CartModule.Aggregate;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.IRepositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetByUserId(string userId);
    }
}
