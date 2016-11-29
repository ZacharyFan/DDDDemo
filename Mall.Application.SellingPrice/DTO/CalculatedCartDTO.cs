namespace Mall.Application.SellingPrice.DTO
{
    public class CalculatedCartDTO
    {
        public string CartId { get; set; }

        public CalculatedFullGroupDTO[] CalculatedFullGroups { get; set; }

        public CalculatedCartItemDTO[] CalculatedCartItems { get; set; } 
    }
}
