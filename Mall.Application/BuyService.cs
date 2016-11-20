using System;
using Mall.Domain;
using Mall.DomainService;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public class BuyService
    {
        private readonly static GetUserCartDomainService _getUserCartDomainService = new GetUserCartDomainService();

        public Result Buy(Guid userId, Guid productId, int quantity)
        {
            var product = DomainRegistry.ProductService().GetProduct(productId);
            if (product == null)
            {
                return Result.Fail("对不起，未能获取产品信息请重试~");
            }

            var cart = _getUserCartDomainService.GetUserCart(userId);
            cart.AddCartItem(productId, quantity, product.SalePrice);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }
    }
}
