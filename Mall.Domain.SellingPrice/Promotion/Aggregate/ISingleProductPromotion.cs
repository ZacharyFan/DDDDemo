using Mall.Domain.SellingPrice.Promotion.ValueObject;

namespace Mall.Domain.SellingPrice.Promotion.Aggregate
{
    /// <summary>
    /// 单产品活动
    /// </summary>
    public interface ISingleProductPromotion
    {
        PromotionContainsProduct GetPromotionContainsProduct();

        bool IsExistedProduct(string productId);
    }
}
