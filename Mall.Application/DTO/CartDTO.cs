using System.Linq;

namespace Mall.Application.DTO
{
    public class CartDTO
    {
        /// <summary>
        /// 有参与满类型活动的购物项组的集合
        /// </summary>
        public CartItemGroupDTO[] CartItemGroups { get; set; }

        /// <summary>
        /// 没有参与满类型活动的购物项集合
        /// </summary>
        public CartItemDTO[] CartItems { get; set; }

        /// <summary>
        /// 总销售价（优惠前的价格）
        /// </summary>
        public decimal TotalSalePrice
        {
            get
            {
                if (CartItems.Length == 0 && CartItemGroups.Length == 0)
                    return 0;

                return CartItems.Sum(ent => ent.SalePrice) + CartItemGroups.Sum(ent => ent.CartItems.Sum(e => e.SalePrice));
            }
        }

        /// <summary>
        /// 总折扣金额
        /// </summary>
        public decimal TotalReducePrice
        {
            get
            {
                if (CartItems.Length == 0 && CartItemGroups.Length == 0)
                    return 0;

                return CartItems.Sum(ent => ent.ReducePrice) + CartItemGroups.Sum(ent => ent.CartItems.Sum(e => e.ReducePrice)) + CartItemGroups.Sum(ent => ent.ReducePrice);
            }
        }

        /// <summary>
        /// 总实际售价
        /// </summary>
        public decimal TotalRealPrice
        {
            get
            {
                return TotalSalePrice - TotalReducePrice;
            }
        }
    }
}
