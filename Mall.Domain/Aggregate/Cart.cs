using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mall.Domain.Entity;

namespace Mall.Domain.Aggregate
{
    public class Cart : Infrastructure.DomainCore.Aggregate
    {
        private readonly List<CartItem> _cartItems;

        public Guid CartId { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime LastChangeTime { get; private set; }

        public Cart(Guid cartId, Guid userId, DateTime lastChangeTime)
        {
            if (cartId == default(Guid))
                throw new ArgumentException("cartId 不能为default(Guid)", "cartId");

            if (userId == default(Guid))
                throw new ArgumentException("userId 不能为default(Guid)", "userId");

            if (lastChangeTime == default(DateTime))
                throw new ArgumentException("lastChangeTime 不能为default(DateTime)", "lastChangeTime");

            this.CartId = cartId;
            this.UserId = userId;
            this.LastChangeTime = lastChangeTime;
            this._cartItems = new List<CartItem>();
        }

        public void AddCartItem(Guid productId, int quantity, decimal price)
        {
            var cartItem = new CartItem(productId, quantity, price);
            var existedCartItem = this._cartItems.SingleOrDefault(ent => ent.ProductId == cartItem.ProductId);
            if (existedCartItem == null)
            {
                this._cartItems.Add(cartItem);
            }
            else
            {
                existedCartItem.ModifyPrice(cartItem.Price); //有可能价格更新了，每次都更新一下。
                existedCartItem.ModifyQuantity(existedCartItem.Quantity + cartItem.Quantity);
            }
        }

        public ReadOnlyCollection<CartItem> GetCartItems()
        {
            return this._cartItems.AsReadOnly();
        }

        public CartItem GetCartItem(Guid productId)
        {
            return this._cartItems.SingleOrDefault(ent => ent.ProductId == productId);
        }

        public int TotalItemCount()
        {
            return this._cartItems.Count;
        }

        public int TotalItemNum()
        {
            if (this._cartItems.Count == 0)
                return 0;
            return this._cartItems.Sum(e => e.Quantity);
        }
    }
}
