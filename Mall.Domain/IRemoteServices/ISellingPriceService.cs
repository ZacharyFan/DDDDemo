using System.Collections.Generic;
using System.Security.Policy;
using Mall.Domain.CartModule.Aggregate;
using Mall.Domain.ValueObject;

namespace Mall.Domain.IRemoteServices
{
    public interface ISellingPriceService
    {
        SellingPriceCart Calculate(Cart cart);

        List<Coupon> CalculateAllCoupons(Cart cart);
    }
}
