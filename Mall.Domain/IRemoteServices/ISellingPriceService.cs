using Mall.Domain.CartModule.Aggregate;
using Mall.Domain.ValueObject;

namespace Mall.Domain.IRemoteServices
{
    public interface ISellingPriceService
    {
        SellingPriceCart Calculate(Cart cart);
    }
}
