using System.Linq;
using Mall.Application.DTO;
using Mall.Domain;
using Mall.Domain.CartModule.Aggregate;
using Mall.Domain.CartModule.Entity;
using Mall.Domain.FavoritesModule.Aggregate;
using Mall.Domain.ValueObject;
using Mall.DomainService;
using Mall.Infrastructure.Results;

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

        public Result ChangeQuantity(string userId, string id, int quantity)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            var cartItem = cart.GetCartItem(id);
            if (cartItem == null)
            {
                return Result.Fail("该购物项已不存在");
            }

            cartItem.ModifyQuantity(quantity);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }

        public Result DeleteCartItem(string userId, string id)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            cart.RemoveCartItem(id);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }

        public Result AddToFavorites(string userId, string productId)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            var cartItem = cart.GetCartItem(productId);
            if (cartItem == null)
            {
                return Result.Fail("该购物项已不存在");
            }

            var favorites = DomainRegistry.FavoritesRepository().GetByUserId(userId) ?? new Favorites(userId, null);
            favorites.AddFavoritesItem(cartItem);
            DomainRegistry.FavoritesRepository().Save(favorites);
            return Result.Success();
        }

        public Result ChangeMultiProductsPromotion(string userId, string productId, string selectedMultiProductsPromotionId)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return Result.Fail("当前购物车中并没有商品");
            }

            var cartItem = cart.GetCartItem(productId);
            if (cartItem == null)
            {
                return Result.Fail("该购物项已不存在");
            }

            cartItem.ChangeMultiProductsPromotion(selectedMultiProductsPromotionId);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
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
