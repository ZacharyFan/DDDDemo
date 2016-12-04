using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public abstract class MultiProductPromotionRule : PromotionRule, IMultiProductsPromotion
    {
        private readonly List<PromotionContainsProduct> _promotionContainsProducts = new List<PromotionContainsProduct>();

        protected MultiProductPromotionRule(string promotionId, string title)
            : base(promotionId, title)
        {
        }

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
