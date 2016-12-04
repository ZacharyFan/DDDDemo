using System;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public abstract class PromotionRule : Infrastructure.DomainCore.Aggregate
    {
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
    }
}
