using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Domain.Order.DomainEvent.Events;
using Mall.Domain.Order.Entity;
using Mall.Infrastructure.DomainCore;
using Mall.Infrastructure.DomainEventCore;

namespace Mall.Domain.Order.Aggregate
{
    public class Order : AggregateRoot
    {
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public string UserId { get; private set; }

        public string Receiver { get; private set; }

        public string CountryId { get; private set; }

        public string CountryName { get; private set; }

        public string ProvinceId { get; private set; }

        public string ProvinceName { get; private set; }

        public string CityId { get; private set; }

        public string CityName { get; private set; }

        public string DistrictId { get; private set; }

        public string DistrictName { get; private set; }

        public string Address { get; private set; }

        public string Mobile { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public string PaymentMethodId { get; private set; }

        public string PaymentMethodName { get; private set; }

        public string ExpressId { get; private set; }

        public string ExpressName { get; private set; }

        public decimal Freight { get; private set; }

        public string CouponId { get; private set; }

        public string CouponName { get; private set; }

        public decimal CouponValue { get; private set; }

        public DateTime OrderTime { get; private set; }

        public DateTime PaidTime { get; private set; }

        public decimal ShouldPayAmount
        {
            get { return this._orderItems.Sum(ent => ent.UnitPrice * ent.Quantity) + Freight - CouponValue; }
        }

        public Order(string orderId, string userId, string receiver, string countryId, string countryName, string provinceId, string provinceName, string cityId, string cityName, string districtId, string districtName, string address, string mobile, string phone, string email, string paymentMethodId, string paymentMethodName, string expressId, string expressName, decimal freight, string couponId, string couponName, decimal couponValue, DateTime orderTime, DateTime paidTime)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("orderId 不能为空", "orderId");

            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("userId 不能为空", "userId");

            if (string.IsNullOrWhiteSpace(receiver))
                throw new ArgumentException("receiver 不能为空", "receiver");

            if (string.IsNullOrWhiteSpace(countryId))
                throw new ArgumentException("countryId 不能为空", "countryId");

            if (string.IsNullOrWhiteSpace(countryName))
                throw new ArgumentException("countryName 不能为空", "countryName");

            if (string.IsNullOrWhiteSpace(provinceId))
                throw new ArgumentException("provinceId 不能为空", "provinceId");

            if (string.IsNullOrWhiteSpace(provinceName))
                throw new ArgumentException("provinceName 不能为空", "provinceName");

            if (string.IsNullOrWhiteSpace(cityId))
                throw new ArgumentException("cityId 不能为空", "cityId");

            if (string.IsNullOrWhiteSpace(cityName))
                throw new ArgumentException("cityName 不能为空", "cityName");

            if (string.IsNullOrWhiteSpace(districtId))
                throw new ArgumentException("districtId 不能为空", "districtId");

            if (string.IsNullOrWhiteSpace(districtName))
                throw new ArgumentException("districtName 不能为空", "districtName");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("address 不能为空", "address");

            if (string.IsNullOrWhiteSpace(mobile))
                throw new ArgumentException("mobile 不能为空", "mobile");

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("phone 不能为空", "phone");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email 不能为空", "email");

            if (string.IsNullOrWhiteSpace(paymentMethodId))
                throw new ArgumentException("paymentMethodId 不能为空", "paymentMethodId");

            if (string.IsNullOrWhiteSpace(paymentMethodName))
                throw new ArgumentException("paymentMethodName 不能为空", "paymentMethodName");

            if (string.IsNullOrWhiteSpace(expressId))
                throw new ArgumentException("expressId 不能为空", "expressId");

            if (string.IsNullOrWhiteSpace(expressName))
                throw new ArgumentException("expressName 不能为空", "expressName");

            if (freight < 0)
                throw new ArgumentException("freight 不能小于0", "freight");

            if (orderTime == default(DateTime))
                throw new ArgumentException("orderTime 不能为默认值", "orderTime");

            this.ID = orderId;
            this.UserId = userId;
            this.Receiver = receiver;
            this.CountryId = countryId;
            this.CountryName = countryName;
            this.ProvinceId = provinceId;
            this.ProvinceName = provinceName;
            this.CityId = cityId;
            this.CityName = cityName;
            this.DistrictId = districtId;
            this.DistrictName = districtName;
            this.Address = address;
            this.Mobile = mobile;
            this.Phone = phone;
            this.Email = email;
            this.PaymentMethodId = paymentMethodId;
            this.PaymentMethodName = paymentMethodName;
            this.ExpressId = expressId;
            this.ExpressName = expressName;
            this.Freight = freight;
            this.CouponId = couponId;
            this.CouponName = couponName;
            this.CouponValue = couponValue;
            this.OrderTime = orderTime;
            this.PaidTime = paidTime;
        }

        public static Order Create(string id, string userId, string receiver, string countryId, string countryName, string provinceId, string provinceName, string cityId, string cityName, string districtId, string districtName, string address, string mobile, string phone, string email, string paymentMethodId, string paymentMethodName, string expressId, string expressName, decimal freight, string couponId, string couponName, decimal couponValue, DateTime orderTime)
        {
            var order = new Order(id, userId, receiver, countryId, countryName, provinceId, provinceName, cityId, cityName, districtId, districtName, address, mobile, phone, email, paymentMethodId, paymentMethodName, expressId, expressName, freight, couponId, couponName, couponValue, orderTime, default(DateTime));

            DomainEventBus.Instance().Publish(new OrderCreated(order.ID, order.UserId, order.Receiver));

            return order;
        }

        public void AddOrderItem(string productId, int quantity, decimal unitPrice, string joinedMultiProductsPromotionId, string productName)
        {
            if (this._orderItems.Any(ent => ent.ID == productId))
                throw new ArgumentException("该orderItem已存在");

            _orderItems.Add(new OrderItem(productId, quantity, unitPrice, joinedMultiProductsPromotionId, productName));
        }
    }
}
