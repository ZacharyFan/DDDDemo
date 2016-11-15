using System;
using Mall.Domain.IRemoteServices;
using Mall.Domain.IRepositories;

namespace Mall.Domain
{
    public class DomainRegistry
    {
        private static IUserService _userService;
        private static IProductService _productService;
        private static ICartRepository _cartRepository;

        public static void RegisterUserService(IUserService userService)
        {
            if (userService == null)
                throw new ArgumentNullException("userService");
            _userService = userService;
        }

        public static void RegisterProductService(IProductService productService)
        {
            if (productService == null)
                throw new ArgumentNullException("productService");
            _productService = productService;
        }

        public static void RegisterCartRepository(ICartRepository cartRepository)
        {
            if (cartRepository == null)
                throw new ArgumentNullException("cartRepository");
            _cartRepository = cartRepository;
        }

        public static IUserService UserService()
        {
            return _userService;
        }

        public static IProductService ProductService()
        {
            return _productService;
        }

        public static ICartRepository CartRepository()
        {
            return _cartRepository;
        }
    }
}
