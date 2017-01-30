using Mall.Domain.IRemoteServices;
using Mall.Domain.ValueObject;
using Mall.Infrastructure.Results;

namespace Mall.Infrastructure.Translators.Order
{
    public class OrderService : IOrderService
    {
        private static readonly OrderAdapter _orderAdapter = new OrderAdapter();
        public Result Create(WaitCreateOrder waitCreateOrder)
        {
            return _orderAdapter.Create(waitCreateOrder);
        }
    }
}
