using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    /// <summary>
    /// 满减
    /// </summary>
    public class PromotionRuleMeetReduction : MultiProductPromotionRule, IMultiProdcutsReducePricePromotion
    {
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal ReducePrice { get; private set; }

        /// <summary>
        /// 满足金额
        /// </summary>
        public decimal MeetPrice { get; private set; }

        public PromotionRuleMeetReduction(string promotionId, string title, decimal meetPrice, decimal reducePrice)
            : base(promotionId, title)
        {
            if (reducePrice <= 0)
                throw new ArgumentException("reducePrice不能小于等于0", "reducePrice");

            if (meetPrice < 0)
                throw new ArgumentException("fullPrice不能小于0", "meetPrice");

            this.ReducePrice = reducePrice;
            this.MeetPrice = meetPrice;
        }

        /// <summary>
        /// 计算减免金额
        /// </summary>
        /// <param name="boughtProducts">购买的商品</param>
        /// <returns></returns>
        public decimal CalculateReducePrice(IEnumerable<BoughtProduct> boughtProducts)
        {
            if (boughtProducts == null)
                return 0;

            var containsProducts = boughtProducts.Join(this.GetPromotionContainsProducts(), l => l.ProductId, r => r.ProductId, (l, r) => l).ToList();
            if (containsProducts.Count == 0)
                return 0;

            var totalProductPrice = containsProducts.Sum(ent => ent.TotalDiscountedPrice);

            if (totalProductPrice < this.MeetPrice)
                return 0;

            return totalProductPrice <= this.ReducePrice ? totalProductPrice : this.ReducePrice;
        }
    }
}
