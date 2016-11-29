using System;
using Mall.Domain.SellingPrice.Promotion.IRepositories;

namespace Mall.Domain
{
    public class DomainRegistry
    {
        private static IPromotionRepository _promotionRepository;

        public static void RegisterUserService(IPromotionRepository promotionRepository)
        {
            if (promotionRepository == null)
                throw new ArgumentNullException("promotionRepository");
            _promotionRepository = promotionRepository;
        }

        public static IPromotionRepository PromotionRepository()
        {
            return _promotionRepository;
        }
    }
}
