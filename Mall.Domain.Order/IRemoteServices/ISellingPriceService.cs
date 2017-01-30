using System;
using Mall.Infrastructure.Results;

namespace Mall.Domain.Order.IRemoteServices
{
    public interface ISellingPriceService
    {
        Result IsCouponCanUse(string id, DateTime orderTime);
    }
}
