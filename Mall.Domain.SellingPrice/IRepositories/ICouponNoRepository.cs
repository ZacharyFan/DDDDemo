using System.Collections.Generic;
using Mall.Domain.SellingPrice.Coupon.Aggregate;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.SellingPrice.IRepositories
{
    public interface ICouponNoRepository : IRepository<CouponNo>
    {
        List<CouponNo> GetNotUsedByUserId(string userId);
    }
}
