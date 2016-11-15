using System;
using System.Collections.Generic;
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

        public void AddCartItem(CartItem cartItem)
        {
            var existedCartItem = this._cartItems.FirstOrDefault(ent => ent.ProductId == cartItem.ProductId);
            if (existedCartItem == null)
            {
                this._cartItems.Add(cartItem);
            }
            else
            {
                existedCartItem.ModifyQuantity(existedCartItem.Quantity + cartItem.Quantity);
            }
        }
    }
}
