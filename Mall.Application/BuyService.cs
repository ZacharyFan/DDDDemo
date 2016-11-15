using System;
using Mall.Domain;
using Mall.DomainService;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public class BuyService
    {
        private readonly static UserBuyProductDomainService _userBuyProductDomainService = new UserBuyProductDomainService();
        private readonly static GetUserCartDomainService _getUserCartDomainService = new GetUserCartDomainService();

        public Result Buy(Guid userId, Guid productId, int quantity)
        {
            var cartItem = _userBuyProductDomainService.UserBuyProduct(userId, productId, quantity);
            var cart = _getUserCartDomainService.GetUserCart(userId);
            cart.AddCartItem(cartItem);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }
    }
}
