using System;
using Mall.Domain.SellingPrice.Coupon.Aggregate;
using Mall.Domain.SellingPrice.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        public string NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(Coupon aggregate)
        {
            throw new NotImplementedException();
        }

        public Coupon GetByIdentity(string identity)
        {
            throw new NotImplementedException();
        }
    }
}
