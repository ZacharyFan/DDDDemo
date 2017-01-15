using System.Collections.Generic;
using Mall.Application.SellingPrice.DTO;

namespace Mall.Application.SellingPrice
{
    public interface ICouponService
    {
        List<CouponDTO> Calculate(CartRequest cart);
    }
}
