using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mall.Domain.SellingPrice.Promotion.Aggregate;

namespace Mall.Domain.SellingPrice.Promotion.ValueObject
{
    public class BoughtProduct
    {
        private readonly List<PromotionRule> _promotionRules = new List<PromotionRule>();

        public string ProductId { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal ReducePrice { get; private set; }

        /// <summary>
        /// 商品在单品优惠后的单价，如果没有优惠则为正常购买的单价
        /// </summary>
        public decimal DiscountedUnitPrice
        {
            get { return UnitPrice - ReducePrice; }
        }

        public decimal TotalDiscountedPrice
        {
            get { return DiscountedUnitPrice * Quantity; }
        }

        public ReadOnlyCollection<ISingleProductPromotion> InSingleProductPromotionRules
        {
            get { return _promotionRules.OfType<ISingleProductPromotion>().ToList().AsReadOnly(); }
        }

        public IMultiProductsPromotion InMultiProductPromotionRule { get; private set; }

        public BoughtProduct(string productId, int quantity, decimal unitPrice, decimal reducePrice, IEnumerable<PromotionRule> promotionRules, string selectedMultiProdcutsPromotionId)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("productId不能为null或者空字符串", "productId");

            if (quantity <= 0)
                throw new ArgumentException("quantity不能小于等于0", "quantity");

            if (unitPrice < 0)
                throw new ArgumentException("unitPrice不能小于0", "unitPrice");

            if (reducePrice < 0)
                throw new ArgumentException("reducePrice不能小于0", "reducePrice");

            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.ReducePrice = reducePrice;

            if (promotionRules != null)
            {
                this._promotionRules.AddRange(promotionRules);
                var multiProductsPromotions = this._promotionRules.OfType<IMultiProductsPromotion>().ToList();
                if (multiProductsPromotions.Count > 0)
                {
                    var selectedMultiProductsPromotionRule = multiProductsPromotions.SingleOrDefault(ent => ((PromotionRule)ent).PromotoinId == selectedMultiProdcutsPromotionId);

                    InMultiProductPromotionRule = selectedMultiProductsPromotionRule ?? multiProductsPromotions.First();
                }
            }
        }

        public BoughtProduct ChangeReducePrice(decimal reducePrice)
        {
            if (reducePrice < 0)
                throw new ArgumentException("reducePrice不能小于0");

            var selectedMultiProdcutsPromotionId = this.InMultiProductPromotionRule == null
                ? null
                : ((PromotionRule) this.InMultiProductPromotionRule).PromotoinId;
            return new BoughtProduct(this.ProductId, this.Quantity, this.UnitPrice, reducePrice, this._promotionRules, selectedMultiProdcutsPromotionId);
        }
    }
}
