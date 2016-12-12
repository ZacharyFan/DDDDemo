using System;
using Mall.Domain.SellingPrice.IRemoteServices;
using Mall.Domain.SellingPrice.IRepositories;
using Mall.Domain.SellingPrice.Promotion.IRepositories;

namespace Mall.Domain.SellingPrice
{
    public class DomainRegistry
    {
        private static IPromotionRepository _promotionRepository;
        private static IUserService _userService;
        private static IRoleDiscountRelationRepository _roleDiscountRelationRepository;

        public static void RegisterPromotionRepository(IPromotionRepository promotionRepository)
        {
            if (promotionRepository == null)
                throw new ArgumentNullException("promotionRepository");
            _promotionRepository = promotionRepository;
        }

        public static void RegisterUserService(IUserService userService)
        {
            if (userService == null)
                throw new ArgumentNullException("userService");
            _userService = userService;
        }

        public static void RegisterRoleDiscountRelationRepository(IRoleDiscountRelationRepository roleDiscountRelationRepository)
        {
            if (roleDiscountRelationRepository == null)
                throw new ArgumentNullException("roleDiscountRelationRepository");
            _roleDiscountRelationRepository = roleDiscountRelationRepository;
        }

        public static IPromotionRepository PromotionRepository()
        {
            return _promotionRepository;
        }

        public static IUserService UserService()
        {
            return _userService;
        }

        public static IRoleDiscountRelationRepository RoleDiscountRelationRepository()
        {
            return _roleDiscountRelationRepository;
        }
    }
}
