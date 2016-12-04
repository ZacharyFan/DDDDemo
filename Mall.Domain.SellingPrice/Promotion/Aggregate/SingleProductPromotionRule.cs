using System;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public abstract class SingleProductPromotionRule : PromotionRule, ISingleProductPromotion
    {
        private readonly PromotionContainsProduct _promotionContainsProduct;

        protected SingleProductPromotionRule(string promotionId, string title, string containsProductId, string containsProductName)
            : base(promotionId, title)
        {
            if (string.IsNullOrWhiteSpace(containsProductId))
                throw new ArgumentNullException("containsProductId");

            if (string.IsNullOrWhiteSpace(containsProductName))
                throw new ArgumentNullException("containsProductName");

            this._promotionContainsProduct = new PromotionContainsProduct(containsProductId, containsProductName);
        }

        public PromotionContainsProduct GetPromotionContainsProduct()
        {
            return this._promotionContainsProduct;
        }

        public bool IsExistedProduct(string productId)
        {
            return this._promotionContainsProduct.ProductId == productId;
        }
    }
}
