using System;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    /// <summary>
    /// 限时折扣
    /// </summary>
    public class PromotionRuleLimitTimeDiscount : SingleProductPromotionRule
    {
        /// <summary>
        /// 限时折扣开始时间
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// 限时折扣结束时间
        /// </summary>
        public DateTime EndTime { get; private set; }

        /// <summary>
        /// 限时售价
        /// </summary>
        public decimal LimitTimePrice { get; private set; }

        public PromotionRuleLimitTimeDiscount(string promotionId, string title, string containsProductId, string containsProductName, DateTime startTime, DateTime endTime, decimal limitTimePrice)
            : base(promotionId, title, containsProductId, containsProductName)
        {
            if (startTime == default(DateTime))
                throw new ArgumentException("startTime不能为default(DateTime)", "startTime");

            if (endTime == default(DateTime))
                throw new ArgumentException("endTime不能为default(DateTime)", "endTime");

            if (limitTimePrice < 0)
                throw new ArgumentException("price不能小于0", "limitTimePrice");

            this.StartTime = startTime;
            this.EndTime = endTime;
            this.LimitTimePrice = limitTimePrice;
        }

        public decimal CalculateReducePrice(string productId, decimal unitPrice, DateTime dateTime)
        {
            if (!this.IsExistedProduct(productId))
                return 0;

            var nowTime = dateTime;
            if (nowTime < this.StartTime || nowTime > this.EndTime)
                return 0;

            return unitPrice - this.LimitTimePrice;
        }
    }
}
