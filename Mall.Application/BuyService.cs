using Mall.Domain;
using Mall.DomainService;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public class BuyService : IBuyService
    {
        private readonly static ConfirmUserCartExistedDomainService _confirmUserCartExistedDomainService = new ConfirmUserCartExistedDomainService();

        public Result Buy(string userId, string productId, int quantity)
        {
            var product = DomainRegistry.ProductService().GetProduct(productId);
            if (product == null)
            {
                return Result.Fail("对不起，未能获取产品信息请重试~");
            }

            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);
            cart.AddCartItem(productId, quantity, product.SalePrice);
            DomainRegistry.CartRepository().Save(cart);
            return Result.Success();
        }
    }
}
