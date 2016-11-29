using System;

namespace Mall.Domain.ValueObject
{
    public class SellingPriceCartItem
    {
        public string ProductId { get; private set; }

        public decimal ReducePrice { get; private set; }

        public SellingPriceCartItem(string productId, decimal reducePrice)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("productIdB不能为空", "productId");

            if (reducePrice < 0)
                throw new ArgumentException("reducePrice不能小于0", "reducePrice");

            this.ProductId = productId;
            this.ReducePrice = reducePrice;
        }
    }
}
