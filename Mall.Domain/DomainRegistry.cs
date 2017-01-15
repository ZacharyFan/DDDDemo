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
        private static ISellingPriceService _sellingPriceService;
        private static IFavoritesRepository _favoritesRepository;
        private static IPaymentService _paymentService;
        private static IExpressRepository _expressRepository;

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

        public static void RegisterSellingPriceService(ISellingPriceService sellingPriceService)
        {
            if (sellingPriceService == null)
                throw new ArgumentNullException("sellingPriceService");
            _sellingPriceService = sellingPriceService;
        }

        public static void RegisterFavoritesRepository(IFavoritesRepository favoritesRepository)
        {
            if (favoritesRepository == null)
                throw new ArgumentNullException("favoritesRepository");
            _favoritesRepository = favoritesRepository;
        }

        public static void RegisterPaymentService(IPaymentService paymentService)
        {
            if (paymentService == null)
                throw new ArgumentNullException("paymentService");
            _paymentService = paymentService;
        }

        public static void RegisterExpressRepository(IExpressRepository expressRepository)
        {
            if (expressRepository == null)
                throw new ArgumentNullException("expressRepository");
            _expressRepository = expressRepository;
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

        public static ISellingPriceService SellingPriceService()
        {
            return _sellingPriceService;
        }

        public static IFavoritesRepository FavoritesRepository()
        {
            return _favoritesRepository;
        }

        public static IPaymentService PaymentService()
        {
            return _paymentService;
        }

        public static IExpressRepository ExpressRepository()
        {
            return _expressRepository;
        }
    }
}
