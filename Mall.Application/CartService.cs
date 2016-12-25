using System.Linq;
using Mall.Application.DTO;
using Mall.Domain;
using Mall.Domain.Aggregate;
using Mall.Domain.Entity;
using Mall.Domain.ValueObject;
using Mall.DomainService;

namespace Mall.Application
{
    public class CartService : ICartService
    {
        private readonly static ConfirmUserCartExistedDomainService _confirmUserCartExistedDomainService = new ConfirmUserCartExistedDomainService();

        public CartDTO GetCart(string userId)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return null;
            }

            var sellingPriceCart = DomainRegistry.SellingPriceService().Calculate(cart);
            return ConvertToCart(cart, sellingPriceCart);
        }

        private CartDTO ConvertToCart(Cart cart, SellingPriceCart sellingPriceCart)
        {
            return new CartDTO
            {
                CartItemGroups = sellingPriceCart.FullGroups.Select(ent => new CartItemGroupDTO
                {
                    CartItems = ent.CartItems.Select(e => ConvertToCartItem(e, cart.GetCartItem(e.ProductId))).ToArray(),
                    ReducePrice = ent.ReducePrice
                }).ToArray(),
                CartItems = sellingPriceCart.CartItems.Select(ent => ConvertToCartItem(ent, cart.GetCartItem(ent.ProductId))).ToArray()
            };
        }

        private CartItemDTO ConvertToCartItem(SellingPriceCartItem sellingPriceCartItem, CartItem cartItem)
        {
            var product = DomainRegistry.ProductService().GetProduct(cartItem.ID);
            return new CartItemDTO
            {
                ProductId = cartItem.ID,
                ProductName = product == null ? "商品已失效" : product.SaleName,
                ReducePrice = sellingPriceCartItem.ReducePrice,
                SalePrice = cartItem.UnitPrice
            };
        }
    }
}
