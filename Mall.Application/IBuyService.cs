using Mall.Application.DTO;
using Mall.Infrastructure.Results;

namespace Mall.Application
{
    public interface IBuyService
    {
        Result Buy(string userId, string productId, int quantity);
    }
}
