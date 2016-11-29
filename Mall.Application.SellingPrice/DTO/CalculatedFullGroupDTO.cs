namespace Mall.Application.SellingPrice.DTO
{
    public class CalculatedFullGroupDTO
    {
        public CalculatedCartItemDTO[] CalculatedCartItems { get; set; }

        public decimal ReducePrice { get; set; }
    }
}
