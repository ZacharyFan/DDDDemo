using System;

namespace Mall.Domain.ValueObject
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Product : Infrastructure.DomainCore.ValueObject
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// 销售名称
        /// </summary>
        public string SaleName { get; private set; }

        /// <summary>
        /// 专柜价
        /// </summary>
        public decimal ShoppePrice { get; private set; }

        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal SalePrice { get; private set; }

        /// <summary>
        /// 销售描述
        /// </summary>
        public string SaleDescription { get; private set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Stock { get; private set; }

        public Product(Guid productId, string saleName, decimal shoppePrice, decimal salePrice, string saleDescription, int stock)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("参数不能为Guid.Empty", "productId");
            if (string.IsNullOrWhiteSpace(saleName))
                throw new ArgumentNullException("saleName");
            if (shoppePrice < 0)
                throw new ArgumentOutOfRangeException("shoppePrice", "参数不能小于0");
            if (salePrice < 0)
                throw new ArgumentOutOfRangeException("salePrice", "参数不能小于0");
            if (stock < 0)
                throw new ArgumentOutOfRangeException("stock", "参数不能小于0");

            this.ProductId = productId;
            this.SaleName = saleName;
            this.ShoppePrice = shoppePrice;
            this.SalePrice = salePrice;
            this.SaleDescription = saleDescription;
            this.Stock = stock;
        }
    }
}
