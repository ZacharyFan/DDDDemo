using System;
using System.Collections.Generic;
using System.Linq;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    /// <summary>
    /// 多买优惠（减免指定数量的最便宜商品）
    /// </summary>
    public class PromotionRuleBuyMoreSomeFree : MultiProductPromotionRule, IMultiProdcutsReducePricePromotion
    {
        /// <summary>
        /// 满足购买的商品数量
        /// </summary>
        public int MeetProductQuantity { get; private set; }

        /// <summary>
        /// 减免的商品数量
        /// </summary>
        public int FreeProductQuantity { get; private set; }

        public PromotionRuleBuyMoreSomeFree(string promotionId, string title, int meetProductQuantity, int freeProductQuantity)
            : base(promotionId, title)
        {
            if (meetProductQuantity <= 0)
                throw new ArgumentException("meetProductQuantity不能小于等于0", "meetProductQuantity");

            if (freeProductQuantity < 0)
                throw new ArgumentException("freeProductQuantity不能小于0", "freeProductQuantity");

            if (meetProductQuantity <= freeProductQuantity)
                throw new ArgumentException("meetProductQuantity不能小于等于freeProductQuantity", "meetProductQuantity");

            this.MeetProductQuantity = meetProductQuantity;
            this.FreeProductQuantity = freeProductQuantity;
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

            int remainingQuantity = this.FreeProductQuantity;
            decimal totalPrice = 0;
            foreach (var product in containsProducts.OrderBy(ent => ent.DiscountedUnitPrice))
            {
                if (remainingQuantity <= 0)
                {
                    return totalPrice;
                }

                totalPrice += (remainingQuantity > product.Quantity ? product.Quantity : remainingQuantity) * product.DiscountedUnitPrice;
                remainingQuantity -= product.Quantity;
            }

            return totalPrice;
        }
    }
}
