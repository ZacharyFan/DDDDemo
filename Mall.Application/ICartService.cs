using Mall.Application.DTO;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public interface ICartService
    {
        CartDTO GetCart(string userId);

        Result ChangeQuantity(string userId, string id, int quantity);

        Result DeleteCartItem(string userId, string id);

        Result AddToFavorites(string userId, string productId);

        Result ChangeMultiProductsPromotion(string userId, string productId, string selectedMultiProductsPromotionId);

        Result SubmitOrder(SumbitOrderRequest request);
    }
}
