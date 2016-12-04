using System.Collections.Generic;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    public interface IMultiProdcutsReducePricePromotion
    {
        decimal CalculateReducePrice(IEnumerable<BoughtProduct> boughtProducts);
    }
}
