using System;
using System.Collections.Generic;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Mall.Domain.SellingPrice.Promotion.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class PromotionSqlServerRepository : IPromotionRepository
    {
        public string NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(PromotionRule aggregate)
        {
            throw new NotImplementedException();
        }

        public void Remove(string identity)
        {
            throw new NotImplementedException();
        }

        public PromotionRule GetByIdentity(string identity)
        {
            throw new NotImplementedException();
        }

        public IList<PromotionRule> GetListByContainsProductId(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
