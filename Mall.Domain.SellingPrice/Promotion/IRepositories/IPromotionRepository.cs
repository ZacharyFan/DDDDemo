using System.Collections;
using System.Collections.Generic;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.SellingPrice.Promotion.IRepositories
{
    public interface IPromotionRepository : IRepository<PromotionRule>
    {
        IList<PromotionRule> GetListByContainsProductId(string productId);
    }
}
