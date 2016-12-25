using System.Linq;
using Mall.Application.SellingPrice;
using Mall.Application.SellingPrice.DTO;
using Mall.Domain.Aggregate;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.SellingPrice
{
    public class SellingPriceAdapter
    {
        private static readonly SellingPriceTranslator _sellingPriceTranslator = new SellingPriceTranslator();
        private static readonly ICalculateSalePriceService _calculateSalePriceService = new CalculateSalePriceService();

        public SellingPriceCart Calculate(Cart cart)
        {
            var dto = _calculateSalePriceService.Calculate(ToRequest(cart));
            return _sellingPriceTranslator.ToSellingPriceCart(dto);
        }

        private CartRequest ToRequest(Cart cart)
        {
            return new CartRequest
            {
                CartItems = cart.GetCartItems().Select(ent => new CartItemRequest
                {
                    ProductId = ent.ID,
                    Quantity = ent.Quantity,
                    UnitPrice = ent.UnitPrice,
                    SelectedMultiProductsPromotionId = ent.SelectedMultiProductsPromotionId
                }).ToArray(),
                CartId = cart.ID,
                UserId = cart.UserId
            };
        }
    }
}
