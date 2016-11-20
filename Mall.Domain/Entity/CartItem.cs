using System;

namespace Mall.Domain.Entity
{
    public class CartItem : Infrastructure.DomainCore.Entity
    {
        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        internal CartItem(Guid productId, int quantity, decimal price)
        {
            if (productId == default(Guid))
                throw new ArgumentException("productId 不能为default(Guid)", "productId");

            if (quantity <= 0)
                throw new ArgumentException("quantity不能小于等于0", "quantity");

            if (price < 0)
                throw new ArgumentException("price不能小于0", "price");

            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
        }

        public void ModifyQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("quantity不能小于等于0", "quantity");

            this.Quantity = quantity;
        }

        public void ModifyPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("price不能小于0", "price");

            this.Price = price;
        }
    }
}
