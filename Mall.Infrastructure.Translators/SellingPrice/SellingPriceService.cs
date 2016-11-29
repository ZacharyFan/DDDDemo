using Mall.Domain.Aggregate;
using Mall.Domain.IRemoteServices;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.SellingPrice
{
    public class SellingPriceService : ISellingPriceService
    {
        private static readonly SellingPriceAdapter _sellingPriceAdapter = new SellingPriceAdapter();

        public SellingPriceCart Calculate(Cart cart)
        {
            return _sellingPriceAdapter.Calculate(cart);
        }
    }
}
