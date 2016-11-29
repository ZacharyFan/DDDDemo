using Mall.Domain.Aggregate;
using Mall.Domain.ValueObject;

namespace Mall.Domain.IRemoteServices
{
    public interface ISellingPriceService
    {
        SellingPriceCart Calculate(Cart cart);
    }
}
