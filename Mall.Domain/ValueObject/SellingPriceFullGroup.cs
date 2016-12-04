using System;
using System.Collections.Generic;
using System.Linq;

namespace Mall.Domain.ValueObject
{
    public class SellingPriceFullGroup
    {
        public SellingPriceCartItem[] CartItems { get; private set; }

        public decimal ReducePrice { get; private set; }

        public string MultiProductsPromotionId { get; private set; }

        public SellingPriceFullGroup(IEnumerable<SellingPriceCartItem> cartItems, decimal reducePrice, string multiProductsPromotionId)
        {
            if (cartItems == null)
                throw new ArgumentNullException("cartItems");

            if (!cartItems.Any())
                throw new ArgumentException("cartItems不能为空");

            if (reducePrice < 0)
                throw new ArgumentException("reducePrice不能小于0");

            this.CartItems = cartItems.ToArray();
            this.ReducePrice = reducePrice;
            this.MultiProductsPromotionId = multiProductsPromotionId;
        }
    }
}
