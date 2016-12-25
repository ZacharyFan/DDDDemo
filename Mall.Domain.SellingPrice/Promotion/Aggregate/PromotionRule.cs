using System;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public abstract class PromotionRule : Infrastructure.DomainCore.AggregateRoot
    {
        public string Title { get; private set; }

        protected PromotionRule(string promotionId, string title)
        {
            if (string.IsNullOrWhiteSpace(promotionId))
                throw new ArgumentNullException("promotionId");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");

            this.ID = promotionId;
            this.Title = title;
        }
    }
}
