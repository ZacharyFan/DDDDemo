using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    /// <summary>
    /// 多买优惠（打折）
    /// </summary>
    public class PromotionRuleBuyMoreDiscount : MultiProductPromotionRule, IMultiProdcutsReducePricePromotion
    {
        /// <summary>
        /// 满足购买的商品数量
        /// </summary>
        public int MeetProductQuantity { get; private set; }

        /// <summary>
        /// 折扣率，整数。如7，则表示7折=30%优惠。
        /// </summary>
        public int DiscountRate { get; private set; }

        public PromotionRuleBuyMoreDiscount(string promotionId, string title, int meetProductQuantity, int discountRate)
            : base(promotionId, title)
        {
            if (meetProductQuantity <= 0)
                throw new ArgumentException("meetProductQuantity不能小于等于0", "meetProductQuantity");

            if (discountRate < 0 || discountRate > 9)
                throw new ArgumentException("discountRate不能小于0或者大于9", "discountRate");

            this.MeetProductQuantity = meetProductQuantity;
            this.DiscountRate = discountRate;
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

            if (containsProducts.Sum(ent => ent.Quantity) < MeetProductQuantity)
                return 0;

            return containsProducts.Sum(ent => ent.TotalDiscountedPrice) * (10 - this.DiscountRate) * 0.1M;
        }
    }
}
