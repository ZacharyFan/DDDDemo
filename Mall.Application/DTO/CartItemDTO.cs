namespace Mall.Application.DTO
{
    public class CartItemDTO
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        /// <summary>
        /// 普通销售价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal ReducePrice { get; set; }

        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal RealPrice
        {
            get { return SalePrice - ReducePrice; }
        }
    }
}
