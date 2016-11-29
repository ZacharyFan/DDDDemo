using System;

namespace Mall.Domain.SellingPrice.Promotion.ValueObject
{
    public class PromotionContainsProduct : Infrastructure.DomainCore.ValueObject
    {
        public string ProductId { get; private set; }

        public string ProductName { get; private set; }

        public PromotionContainsProduct(string productId, string productName)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentNullException("productId");

            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentNullException("productName");

            this.ProductId = productId;
            this.ProductName = productName;
        }
    }
}
