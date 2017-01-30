namespace Mall.Application.Order.DTO
{
    public class OrderItemRequest
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string JoinedMultiProductsPromotionId { get; set; }

        public string ProductName { get; set; }
    }
}
