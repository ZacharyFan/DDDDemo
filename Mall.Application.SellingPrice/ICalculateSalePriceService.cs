using Mall.Application.SellingPrice.DTO;

namespace Mall.Application.SellingPrice
{
    public interface ICalculateSalePriceService
    {
        CalculatedCartDTO Calculate(CartRequest cart);
    }
}
