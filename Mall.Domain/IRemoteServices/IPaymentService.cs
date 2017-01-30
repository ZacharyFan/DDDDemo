using System.Collections.Generic;
using Mall.Domain.ValueObject;

namespace Mall.Domain.IRemoteServices
{
    public interface IPaymentService
    {
        List<PaymentMethod> GetAllPaymentMethods();

        Wallet GetWalletByUserId(string userId);

        PaymentMethod GetPaymentMethod(string id);
    }
}
