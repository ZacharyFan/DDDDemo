using Mall.Application.DTO;

namespace Mall.Application
{
    public interface ICartService
    {
        CartDTO GetCart(string userId);
    }
}
