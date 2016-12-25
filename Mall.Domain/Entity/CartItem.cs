using System;

namespace Mall.Domain.Entity
{
    public class CartItem : Infrastructure.DomainCore.Entity
    {
        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public string SelectedMultiProductsPromotionId { get; private set; }

        internal CartItem(string productId, int quantity, decimal unitPrice, string selectedMultiProductsPromotionId)
        {
            if (string.IsNullOrWhiteSpace(productId))
                throw new ArgumentException("productId 不能为空", "productId");

            if (quantity <= 0)
                throw new ArgumentException("quantity不能小于等于0", "quantity");

            if (unitPrice < 0)
                throw new ArgumentException("unitPrice不能小于0", "unitPrice");

            this.ID = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.SelectedMultiProductsPromotionId = selectedMultiProductsPromotionId;
        }

        public void ModifyQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("quantity不能小于等于0", "quantity");

            this.Quantity = quantity;
        }

        public void ModifyUnitPrice(decimal unitPrice)
        {
            if (unitPrice < 0)
                throw new ArgumentException("unitPrice不能小于0", "unitPrice");

            this.UnitPrice = unitPrice;
        }

        public void ChangeMultiProductsPromotion(string selectedMultiProductsPromotionId)
        {
            this.SelectedMultiProductsPromotionId = selectedMultiProductsPromotionId;
        }
    }
}
