namespace Mall.Application.SellingPrice.DTO
{
    public class CartItemRequest
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string SelectedMultiProductsPromotionId { get; set; }
    }
}
