namespace Mall.Application.SellingPrice.DTO
{
    public class CartRequest
    {
        public string CartId { get; set; }

        public string UserId { get; set; }

        public CartItemRequest[] CartItems { get; set; }
    }
}
