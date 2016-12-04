using System;
using System.Collections.Generic;
using Mall.Domain.SellingPrice.Promotion.Aggregate;

namespace Mall.DomainService.SellingPrice
{
    /// <summary>
    /// 合并单个购买商品所参与的单品促销优惠数据。
    /// </summary>
    public class MergeSingleProductPromotionForOneProductDomainService
    {
        /// <summary>
        /// 合并，目前仅存在一种情况即限制折扣。
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="unitPrice"></param>
        /// <param name="singleProductPromotionRules"></param>
        /// <returns></returns>
        public decimal Merge(string productId, decimal unitPrice, IEnumerable<ISingleProductPromotion> singleProductPromotionRules)
        {
            decimal reducePrice = 0;

            foreach (var promotionRule in singleProductPromotionRules)
            {
                var tempReducePrice = ((PromotionRuleLimitTimeDiscount)promotionRule).CalculateReducePrice(productId, unitPrice, DateTime.Now);  //在创建的时候约束促销的重复性。此处逻辑上允许重复
                if (unitPrice - reducePrice <= tempReducePrice)
                {
                    reducePrice = unitPrice;
                }
                else
                {
                    reducePrice += tempReducePrice;
                }
            }

            return reducePrice;
        }
    }
}
