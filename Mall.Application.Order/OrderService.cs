using Mall.Application.Order.DTO;
using Mall.Domain.Order;
using Mall.Domain.Order.DomainEvent.Events;
using Mall.Infrastructure.DomainEventCore;
using Mall.Infrastructure.Results;

namespace Mall.Application.Order
{
    public class OrderService : IOrderService
    {
        public Result Create(OrderRequest orderRequest)
        {
            if (!string.IsNullOrWhiteSpace(orderRequest.CouponId))
            {
                var couponResult = DomainRegistry.SellingPriceService().IsCouponCanUse(orderRequest.CouponId, orderRequest.OrderTime);
                if (!couponResult.IsSuccess)
                    return Result.Fail(couponResult.Msg);
            }

            var orderId = DomainRegistry.OrderRepository().NextIdentity();
            var order = Domain.Order.Aggregate.Order.Create(orderId, orderRequest.UserId, orderRequest.Receiver,
                orderRequest.CountryId, orderRequest.CountryName, orderRequest.ProvinceId, orderRequest.ProvinceName,
                orderRequest.CityId, orderRequest.CityName, orderRequest.DistrictId, orderRequest.DistrictName,
                orderRequest.Address, orderRequest.Mobile, orderRequest.Phone, orderRequest.Email,
                orderRequest.PaymentMethodId, orderRequest.PaymentMethodName, orderRequest.ExpressId,
                orderRequest.ExpressName, orderRequest.Freight, orderRequest.CouponId, orderRequest.CouponName, orderRequest.CouponValue, orderRequest.OrderTime);

            foreach (var orderItemRequest in orderRequest.OrderItems)
            {
                order.AddOrderItem(orderItemRequest.ProductId, orderItemRequest.Quantity, orderItemRequest.UnitPrice, orderItemRequest.JoinedMultiProductsPromotionId, orderItemRequest.ProductName);
            }

            DomainRegistry.OrderRepository().Save(order);
            DomainEventBus.Instance().Publish(new OrderCreated(order.ID, order.UserId, order.Receiver));
            return Result.Success();
        }
    }
}
