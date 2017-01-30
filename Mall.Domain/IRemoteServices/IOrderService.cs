using Mall.Domain.ValueObject;
using Mall.Infrastructure.Results;

namespace Mall.Domain.IRemoteServices
{
    public interface IOrderService
    {
        Result Create(WaitCreateOrder waitCreateOrder);
    }
}
