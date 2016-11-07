using System;
using Mall.Domain.IRemoteServices;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public class BuyService
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public BuyService(IUserService userService, IProductService productService)
        {
            this._userService = userService;
            this._productService = productService;
        }

        //public Result Buy(Guid userId, Guid productId)
        //{
        //    var user = _userService.GetUser(userId);
        //    if (user == null)
        //    {
        //        return Result.Fail("未找到用户信息");
        //    }

        //    var product = _productService.GetProduct(productId);
        //    if(product == null)
        //    {
        //        return Result.Fail("未找到产品信息");
        //    }

        //    return null;
        //}
    }
}
