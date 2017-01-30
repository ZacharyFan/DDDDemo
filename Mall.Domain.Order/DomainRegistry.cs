using System;
using Mall.Domain.Order.IRemoteServices;
using Mall.Domain.Order.IRepositories;

namespace Mall.Domain.Order
{
    public class DomainRegistry
    {
        private static IOrderRepository _orderRepository;
        private static ISellingPriceService _sellingPriceService;

        public static void RegisterOrderRepository(IOrderRepository orderRepository)
        {
            if (orderRepository == null)
                throw new ArgumentNullException("orderRepository");
            _orderRepository = orderRepository;
        }

        public static void RegisterSellingPriceService(ISellingPriceService sellingPriceService)
        {
            if (sellingPriceService == null)
                throw new ArgumentNullException("sellingPriceService");
            _sellingPriceService = sellingPriceService;
        }

        public static IOrderRepository OrderRepository()
        {
            return _orderRepository;
        }

        public static ISellingPriceService SellingPriceService()
        {
            return _sellingPriceService;
        }
    }
}
