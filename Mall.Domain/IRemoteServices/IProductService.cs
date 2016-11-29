using Mall.Domain.ValueObject;

namespace Mall.Domain.IRemoteServices
{
    public interface IProductService
    {
        Product GetProduct(string productId);
    }
}
