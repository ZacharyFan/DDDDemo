using System.Collections.ObjectModel;
using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    /// <summary>
    /// 多产品活动
    /// </summary>
    public interface IMultiProductsPromotion
    {
        ReadOnlyCollection<PromotionContainsProduct> GetPromotionContainsProducts();

        void JoinProduct(string productId, string productName);

        void RemoveProduct(string productId);

        bool IsExistedProduct(string productId);
    }
}
