using System;

namespace Mall.Domain.ValueObject
{
    public class WaitCreateOrderItem
    {
        public string ProductId { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public string JoinedMultiProductsPromotionId { get; private set; }

        public string ProductName { get; private set; }

        public WaitCreateOrderItem(string productId, int quantity, decimal unitPrice, string joinedMultiProductsPromotionId, string productName)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("productId 不能为空", "productId");

            if (quantity <= 0)
                throw new ArgumentException("quantity不能小于等于0", "quantity");

            if (unitPrice < 0)
                throw new ArgumentException("unitPrice不能小于0", "unitPrice");

            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("productName 不能为空", "productName");

            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.JoinedMultiProductsPromotionId = joinedMultiProductsPromotionId;
            this.ProductName = productName;
        }
    }
}
