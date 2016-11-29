using System;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public class PromotionRuleLimitTimeDiscount : PromotionRule
    {
        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public decimal Price { get; private set; }

        public PromotionRuleLimitTimeDiscount(string promotionId, string title, DateTime startTime, DateTime endTime, decimal price)
            : base(promotionId, title)
        {
            if (startTime == default(DateTime))
                throw new ArgumentException("startTime不能为default(DateTime)", "startTime");

            if (endTime == default(DateTime))
                throw new ArgumentException("endTime不能为default(DateTime)", "endTime");

            if (price < 0)
                throw new ArgumentException("price不能小于0", "price");

            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Price = price;
        }

        public decimal CalculateReducePrice(string productId, decimal unitPrice, DateTime dateTime)
        {
            if (!this.IsExistedProduct(productId))
                return 0;

            var nowTime = dateTime;
            if (nowTime < this.StartTime || nowTime > this.EndTime)
                return 0;

            return unitPrice - this.Price;
        }

        public override bool IsFullPromotion()
        {
            return false;
        }
    }
}
