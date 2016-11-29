using System;
using System.Collections.Generic;
using System.Linq;

namespace Mall.Domain.ValueObject
{
    public class SellingPriceCart
    {
        public string CartId { get; private set; }

        public SellingPriceFullGroup[] FullGroups { get; private set; }

        public SellingPriceCartItem[] CartItems { get; private set; }

        public SellingPriceCart(string cartId, IEnumerable<SellingPriceFullGroup> sellingPriceFullGroups, IEnumerable<SellingPriceCartItem> cartItems)
        {
            if (string.IsNullOrWhiteSpace(cartId))
                throw new ArgumentException("cartId不能为空", "cartId");

            this.CartId = cartId;
            this.FullGroups = (sellingPriceFullGroups ?? new SellingPriceFullGroup[0]).ToArray();
            this.CartItems = (cartItems ?? new SellingPriceCartItem[0]).ToArray();
        }
    }
}
