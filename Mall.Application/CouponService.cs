using System.Collections.Generic;
using System.Linq;
using Mall.Application.DTO;
using Mall.Domain;
using Mall.DomainService;

namespace Mall.Application
{
    public class CouponService : ICouponService
    {
        private readonly static ConfirmUserCartExistedDomainService _confirmUserCartExistedDomainService = new ConfirmUserCartExistedDomainService();

        public List<CouponDTO> GetAllCoupons(string userId)
        {
            var cart = _confirmUserCartExistedDomainService.GetUserCart(userId);

            if (cart.IsEmpty())
            {
                return null;
            }

            var coupons = DomainRegistry.SellingPriceService().CalculateAllCoupons(cart);
            return coupons.Select(ent => new CouponDTO
            {
                CanUse = ent.CanUse,
                ExpiryDate = ent.ExpiryDate,
                ID = ent.ID,
                Name = ent.Name,
                Value = ent.Value
            }).ToList();
        }
    }
}
