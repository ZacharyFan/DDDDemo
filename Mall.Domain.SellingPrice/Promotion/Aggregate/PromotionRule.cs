using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public abstract class PromotionRule : Infrastructure.DomainCore.Aggregate
    {
        private readonly List<PromotionContainsProduct> _promotionContainsProducts = new List<PromotionContainsProduct>();

        public string PromotoinId { get; private set; }

        public string Title { get; private set; }

        protected PromotionRule(string promotionId, string title)
        {
            if (string.IsNullOrWhiteSpace(promotionId))
                throw new ArgumentNullException("promotionId");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");

            this.PromotoinId = promotionId;
            this.Title = title;
        }

        public abstract bool IsFullPromotion();

        public ReadOnlyCollection<PromotionContainsProduct> GetPromotionContainsProducts()
        {
            return this._promotionContainsProducts.AsReadOnly();
        }

        public void JoinProduct(string productId, string productName)
        {
            if (this.IsExistedProduct(productId))
            {
                return;
            }

            var promotionContainsProduct = new PromotionContainsProduct(productId, productName);
            this._promotionContainsProducts.Add(promotionContainsProduct);
        }

        public void RemoveProduct(string productId)
        {
            var promotionContainsProduct = this._promotionContainsProducts.SingleOrDefault(ent => ent.ProductId == productId);
            if (promotionContainsProduct == null)
                return;

            this._promotionContainsProducts.Remove(promotionContainsProduct);
        }

        public bool IsExistedProduct(string productId)
        {
            return this._promotionContainsProducts.Any(ent => ent.ProductId == productId);
        }
    }
}
