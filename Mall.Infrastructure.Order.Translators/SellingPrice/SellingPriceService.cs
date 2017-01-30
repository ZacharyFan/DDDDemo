using System;
using Mall.Domain.Order.IRemoteServices;
using Mall.Infrastructure.Results;

namespace Mall.Infrastructure.Order.Translators.SellingPrice
{
    public class SellingPriceService : ISellingPriceService
    {
        private static readonly SellingPriceAdapter _sellingPriceAdapter = new SellingPriceAdapter();
        public Result IsCouponCanUse(string id, DateTime orderTime)
        {
            return _sellingPriceAdapter.IsCouponCanUse(id, orderTime);
        }
    }
}
