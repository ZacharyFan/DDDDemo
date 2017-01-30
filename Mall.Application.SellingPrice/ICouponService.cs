using System;
using System.Collections.Generic;
using Mall.Application.SellingPrice.DTO;
using Mall.Infrastructure.Results;

namespace Mall.Application.SellingPrice
{
    public interface ICouponService
    {
        List<CouponDTO> Calculate(CartRequest cart);

        Result IsCouponCanUse(string id, DateTime orderTime);

        CouponDTO GetCoupon(string id);
    }
}
