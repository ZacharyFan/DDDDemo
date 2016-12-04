using Mall.Application.SellingPrice.DTO;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Application.SellingPrice.Mapper
{
    public static class ValueObjectToDTO
    {
        public static CalculatedCartItemDTO ToDTO(this BoughtProduct boughtProduct)
        {
            return new CalculatedCartItemDTO
            {
                ProductId = boughtProduct.ProductId,
                ReducePrice = boughtProduct.ReducePrice
            };
        }
    }
}
