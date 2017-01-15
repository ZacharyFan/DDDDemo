using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.SellingPrice.IRepositories
{
    public interface ICouponRepository : IRepository<Coupon.Aggregate.Coupon>
    {
    }
}
