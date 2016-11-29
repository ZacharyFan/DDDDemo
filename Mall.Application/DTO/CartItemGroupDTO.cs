namespace Mall.Application.DTO
{
    public class CartItemGroupDTO
    {
        public CartItemDTO[] CartItems { get; set; }

        public decimal ReducePrice { get; set; } 
    }
}
