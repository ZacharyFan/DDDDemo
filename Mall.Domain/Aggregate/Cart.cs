using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mall.Domain.Entity;

namespace Mall.Domain.Aggregate
{
    public class Cart : Infrastructure.DomainCore.AggregateRoot
    {
        private readonly List<CartItem> _cartItems;

        public string UserId { get; private set; }

        public DateTime LastChangeTime { get; private set; }

        public Cart(string cartId, string userId, DateTime lastChangeTime)
        {
            if (string.IsNullOrWhiteSpace(cartId))
                throw new ArgumentException("cartId 不能为空", "cartId");

            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("userId 不能为空", "userId");

            if (lastChangeTime == default(DateTime))
                throw new ArgumentException("lastChangeTime 不能为default(DateTime)", "lastChangeTime");

            this.ID = cartId;
            this.UserId = userId;
            this.LastChangeTime = lastChangeTime;
            this._cartItems = new List<CartItem>();
        }

        public void AddCartItem(string productId, int quantity, decimal price)
        {
            var cartItem = new CartItem(productId, quantity, price, null);
            var existedCartItem = this._cartItems.SingleOrDefault(ent => ent.ID == cartItem.ID);
            if (existedCartItem == null)
            {
                this._cartItems.Add(cartItem);
            }
            else
            {
                existedCartItem.ModifyUnitPrice(cartItem.UnitPrice); //有可能价格更新了，每次都更新一下。
                existedCartItem.ModifyQuantity(existedCartItem.Quantity + cartItem.Quantity);
            }
        }

        public ReadOnlyCollection<CartItem> GetCartItems()
        {
            return this._cartItems.AsReadOnly();
        }

        public CartItem GetCartItem(string productId)
        {
            return this._cartItems.SingleOrDefault(ent => ent.ID == productId);
        }

        public bool IsEmpty()
        {
            return this._cartItems.Count == 0;
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
