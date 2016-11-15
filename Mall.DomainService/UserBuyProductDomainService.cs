using System;
using Mall.Domain;
using Mall.Domain.Entity;

namespace Mall.DomainService
{
    public class UserBuyProductDomainService
    {
        public CartItem UserBuyProduct(Guid userId, Guid productId, int quantity)
        {
            var user = DomainRegistry.UserService().GetUser(userId);
            if (user == null)
            {
                throw new ApplicationException("未能获取用户信息！");
            }

            var product = DomainRegistry.ProductService().GetProduct(productId);
            if (product == null)
            {
                throw new ApplicationException("未能获取产品信息！");
            }

            return new CartItem(productId, quantity, product.SalePrice);
        }
    }
}
