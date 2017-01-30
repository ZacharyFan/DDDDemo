using System.Linq;
using Mall.Application.Order;
using Mall.Application.Order.DTO;
using Mall.Domain.ValueObject;
using Mall.Infrastructure.Results;

namespace Mall.Infrastructure.Translators.Order
{
    public class OrderAdapter
    {
        private static readonly IOrderService _orderService = new Application.Order.OrderService();

        public Result Create(WaitCreateOrder waitCreateOrder)
        {
            return _orderService.Create(ToOrderRequest(waitCreateOrder));
        }

        public OrderRequest ToOrderRequest(WaitCreateOrder localData)
        {
            return new OrderRequest
            {
                CartId = localData.CartId,
                UserId = localData.UserId,
                Receiver = localData.Receiver,
                CountryId = localData.CountryId,
                CountryName = localData.CountryName,
                ProvinceId = localData.ProvinceId,
                ProvinceName = localData.ProvinceName,
                CityId = localData.CityId,
                CityName = localData.CityName,
                DistrictId = localData.DistrictId,
                DistrictName = localData.DistrictName,
                Address = localData.Address,
                Mobile = localData.Mobile,
                Phone = localData.Phone,
                Email = localData.Email,
                PaymentMethodId = localData.PaymentMethodId,
                PaymentMethodName = localData.PaymentMethodName,
                ExpressId = localData.ExpressId,
                ExpressName = localData.ExpressName,
                Freight = localData.Freight,
                CouponId = localData.CouponId,
                CouponName = localData.CouponName,
                CouponValue = localData.CouponValue,
                OrderTime = localData.OrderTime,
                OrderItems = localData.OrderItems.Select(ent => new OrderItemRequest
                {
                    ProductId = ent.ProductId,
                    ProductName = ent.ProductName,
                    Quantity = ent.Quantity,
                    JoinedMultiProductsPromotionId = ent.JoinedMultiProductsPromotionId,
                    UnitPrice = ent.UnitPrice
                }).ToArray()
            };
        }
    }
}
