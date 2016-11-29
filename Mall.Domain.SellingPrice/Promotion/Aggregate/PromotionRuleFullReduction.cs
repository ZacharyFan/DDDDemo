using System;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public class PromotionRuleFullReduction : PromotionRule
    {
        public decimal ReducePrice { get; private set; }

        public decimal FullPrice { get; private set; }

        public PromotionRuleFullReduction(string promotionId, string title, decimal fullPrice, decimal reducePrice)
            : base(promotionId, title)
        {
            if (reducePrice <= 0)
                throw new ArgumentException("reducePrice不能小于等于0", "reducePrice");

            if (fullPrice < 0)
                throw new ArgumentException("fullPrice不能小于0", "fullPrice");

            this.ReducePrice = reducePrice;
            this.FullPrice = fullPrice;
        }

        ///// <summary>
        ///// 计算减免金额
        ///// </summary>
        ///// <param name="totalProductPrice">产品ID和已优惠后的价格</param>
        ///// <returns></returns>
        //public decimal CalculateReducePrice(decimal totalProductPrice)
        //{
        //    if (totalProductPrice < this.FullPrice)
        //        return 0;

        //    if (totalProductPrice <= this.ReducePrice)
        //        return totalProductPrice;

        //    return this.ReducePrice;
        //}

        public override bool IsFullPromotion()
        {
            return true;
        }
    }
}
