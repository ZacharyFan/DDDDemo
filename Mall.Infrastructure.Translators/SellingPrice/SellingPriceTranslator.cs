using System.Linq;
using Mall.Application.SellingPrice.DTO;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.SellingPrice
{
    public class SellingPriceTranslator
    {
        public SellingPriceCart ToSellingPriceCart(CalculatedCartDTO cartDTO)
        {
            var fullGroups = cartDTO.CalculatedFullGroups.Select(ToSellingPriceFullGroup);
            var cartItems = cartDTO.CalculatedCartItems.Select(ToSellingPriceCartItem);
            return new SellingPriceCart(cartDTO.CartId, fullGroups, cartItems);
        }

        public SellingPriceFullGroup ToSellingPriceFullGroup(CalculatedFullGroupDTO dto)
        {
            return new SellingPriceFullGroup(dto.CalculatedCartItems.Select(ToSellingPriceCartItem), dto.ReducePrice);
        }

        public SellingPriceCartItem ToSellingPriceCartItem(CalculatedCartItemDTO dto)
        {
            return new SellingPriceCartItem(dto.ProductId, dto.ReducePrice);
        }
    }
}
