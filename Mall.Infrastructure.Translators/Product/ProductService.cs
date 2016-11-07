using System;
using Mall.Domain.IRemoteServices;

namespace Mall.Infrastructure.Translators.Product
{
    public class ProductService : IProductService
    {
        private static readonly ProductAdapter _productAdapter = new ProductAdapter();
        public Domain.ValueObject.Product GetProduct(Guid productId)
        {
            return _productAdapter.GetProduct(productId);
        }
    }
}
