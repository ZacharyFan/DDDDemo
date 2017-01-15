using System.Collections.Generic;
using Mall.Application.DTO;

namespace Mall.Application
{
    public interface ICouponService
    {
        List<CouponDTO> GetAllCoupons(string userId);
    }
}
