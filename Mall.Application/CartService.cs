using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Application.DTO;
using Mall.Domain;
using Mall.Domain.CartModule.Aggregate;
using Mall.Domain.CartModule.Entity;
using Mall.Domain.DeliveryModule.Aggregate;
using Mall.Domain.FavoritesModule.Aggregate;
using Mall.Domain.ValueObject;
using Mall.DomainService;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public class CartService : ICartService
    {
        private readonly static ConfirmUserCartExistedDomainService _confirmUserCartExistedDomainService = new ConfirmUserCartExistedDomainService();

        public CartDTO GetCart(string userId)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return null;
            }

            var sellingPriceCart = DomainRegistry.SellingPriceService().Calculate(cart);
            return ConvertToCart(cart, sellingPriceCart);
        }

        public Result ChangeQuantity(string userId, string id, int quantity)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            var cartItem = cart.GetCartItem(id);
            if (cartItem == null)
            {
                return Result.Fail("该购物项已不存在");
            }

            cartItem.ModifyQuantity(quantity);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }

        public Result DeleteCartItem(string userId, string id)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            cart.RemoveCartItem(id);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }

        public Result AddToFavorites(string userId, string productId)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            var cartItem = cart.GetCartItem(productId);
            if (cartItem == null)
            {
                return Result.Fail("该购物项已不存在");
            }

            var favorites = DomainRegistry.FavoritesRepository().GetByUserId(userId) ?? new Favorites(userId, null);
            favorites.AddFavoritesItem(cartItem);
            DomainRegistry.FavoritesRepository().Save(favorites);
            return Result.Success();
        }

        public Result ChangeMultiProductsPromotion(string userId, string productId, string selectedMultiProductsPromotionId)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            var cartItem = cart.GetCartItem(productId);
            if (cartItem == null)
            {
                return Result.Fail("该购物项已不存在");
            }

            cartItem.ChangeMultiProductsPromotion(selectedMultiProductsPromotionId);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }

        public Result SubmitOrder(SumbitOrderRequest request)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(request.UserId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            var sellingPriceCart = DomainRegistry.SellingPriceService().Calculate(cart);

            var shippingAddress = DomainRegistry.UserService().GetShippingAddress(request.ShippingAddressId);
            if (shippingAddress == null)
            {
                return Result.Fail("对不起，你选择的收货地址已不存在！");
            }

            var paymentMethod = DomainRegistry.PaymentService().GetPaymentMethod(request.PaymentMethodId);
            if (paymentMethod == null)
            {
                return Result.Fail("对不起，你选择的支付方式已不存在！");
            }

            var express = DomainRegistry.ExpressRepository().GetByIdentity(request.ExpressId);
            if (express == null)
            {
                return Result.Fail("对不起，你选择的配送方式已不存在！");
            }

            var coupon = DomainRegistry.SellingPriceService().GetCoupon(request.CouponId);
            if (coupon == null)
            {
                return Result.Fail("对不起，你选择的礼券不存在！");
            }
            if (coupon.CanUse)
            {
                return Result.Fail("对不起，你选择的礼券已使用！");
            }
            if (coupon.ExpiryDate < DateTime.Now)
            {
                return Result.Fail("对不起，你选择的礼券已过期！");
            }

            var waitCreateOrder = ConvertToWaitCreateOrder(cart, sellingPriceCart, shippingAddress, paymentMethod,
                express, coupon);
            return DomainRegistry.OrderService().Create(waitCreateOrder);
        }

        private CartDTO ConvertToCart(Cart cart, SellingPriceCart sellingPriceCart)
        {
            return new CartDTO
            {
                CartItemGroups = sellingPriceCart.FullGroups.Select(ent => new CartItemGroupDTO
                {
                    CartItems = ent.CartItems.Select(e => ConvertToCartItem(e, cart.GetCartItem(e.ProductId))).ToArray(),
                    ReducePrice = ent.ReducePrice
                }).ToArray(),
                CartItems = sellingPriceCart.CartItems.Select(ent => ConvertToCartItem(ent, cart.GetCartItem(ent.ProductId))).ToArray()
            };
        }

        private CartItemDTO ConvertToCartItem(SellingPriceCartItem sellingPriceCartItem, CartItem cartItem)
        {
            var product = DomainRegistry.ProductService().GetProduct(cartItem.ID);
            return new CartItemDTO
            {
                ProductId = cartItem.ID,
                ProductName = product == null ? "商品已失效" : product.SaleName,
                ReducePrice = sellingPriceCartItem.ReducePrice,
                SalePrice = cartItem.UnitPrice
            };
        }

        private WaitCreateOrder ConvertToWaitCreateOrder(Cart cart, SellingPriceCart sellingPriceCart, ShippingAddress shippingAddress, PaymentMethod paymentMethod, Express express, Coupon coupon)
        {
            var orderItems = new List<WaitCreateOrderItem>();
            foreach (var sellingPriceFullGroup in sellingPriceCart.FullGroups)
            {
                foreach (var sellingPriceCartItem in sellingPriceFullGroup.CartItems)
                {
                    var cartItem = cart.GetCartItem(sellingPriceCartItem.ProductId);
                    var product = DomainRegistry.ProductService().GetProduct(cartItem.ID);

                    var unitPrice = cartItem.UnitPrice - sellingPriceCartItem.ReducePrice;
                    orderItems.Add(new WaitCreateOrderItem(sellingPriceCartItem.ProductId, cartItem.Quantity, unitPrice, sellingPriceFullGroup.MultiProductsPromotionId, product.SaleName));
                }
            }

            foreach (var sellingPriceCartItem in sellingPriceCart.CartItems)
            {
                var cartItem = cart.GetCartItem(sellingPriceCartItem.ProductId);
                var product = DomainRegistry.ProductService().GetProduct(cartItem.ID);

                orderItems.Add(new WaitCreateOrderItem(sellingPriceCartItem.ProductId, cartItem.Quantity, cartItem.UnitPrice, null, product.SaleName));
            }

            return new WaitCreateOrder(cart.ID, cart.UserId, shippingAddress.Receiver, shippingAddress.CountryId, shippingAddress.CountryName, shippingAddress.ProvinceId, shippingAddress.ProvinceName, shippingAddress.CityId, shippingAddress.CityName, shippingAddress.DistrictId, shippingAddress.DistrictName, shippingAddress.Address, shippingAddress.Mobile, shippingAddress.Phone, shippingAddress.Email, paymentMethod.ID, paymentMethod.Name, express.ID, express.Name, express.Freight, coupon.ID, coupon.Name, coupon.Value, DateTime.Now, orderItems);
        }
    }
}
