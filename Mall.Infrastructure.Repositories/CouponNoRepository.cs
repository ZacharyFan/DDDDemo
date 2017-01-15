using System;
using System.Collections.Generic;
using Mall.Domain.SellingPrice.Coupon.Aggregate;
using Mall.Domain.SellingPrice.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class CouponNoRepository : ICouponNoRepository
    {
        public string NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(CouponNo aggregate)
        {
            throw new NotImplementedException();
        }

        public CouponNo GetByIdentity(string identity)
        {
            throw new NotImplementedException();
        }

        public List<CouponNo> GetNotUsedByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
