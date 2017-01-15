using System;
using Mall.Domain.SellingPrice.IRemoteServices;
using Mall.Domain.SellingPrice.IRepositories;

namespace Mall.Domain.SellingPrice
{
    public class DomainRegistry
    {
        private static IPromotionRepository _promotionRepository;
        private static IUserService _userService;
        private static IRoleDiscountRelationRepository _roleDiscountRelationRepository;
        private static ICouponRepository _couponRepository;
        private static ICouponNoRepository _couponNoRepository;

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

        public static void RegisterCouponRepository(ICouponRepository couponRepository)
        {
            if (couponRepository == null)
                throw new ArgumentNullException("couponRepository");
            _couponRepository = couponRepository;
        }

        public static void RegisterCouponNoRepository(ICouponNoRepository couponNoRepository)
        {
            if (couponNoRepository == null)
                throw new ArgumentNullException("couponNoRepository");
            _couponNoRepository = couponNoRepository;
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

        public static ICouponRepository CouponRepository()
        {
            return _couponRepository;
        }

        public static ICouponNoRepository CouponNoRepository()
        {
            return _couponNoRepository;
        }
    }
}
