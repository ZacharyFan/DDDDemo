using System;
using Mall.Application.SellingPrice;
using Mall.Infrastructure.Results;

namespace Mall.Infrastructure.Order.Translators.SellingPrice
{
    public class SellingPriceAdapter
    {
        private static readonly SellingPriceTranslator _sellingPriceTranslator = new SellingPriceTranslator();
        private static readonly ICouponService _couponService = new CouponService();

        public Result IsCouponCanUse(string couponId, DateTime orderTime)
        {
            return _couponService.IsCouponCanUse(couponId, orderTime);
        }
    }
}
