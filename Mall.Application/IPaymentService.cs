using System.Collections.Generic;
using Mall.Application.DTO;

namespace Mall.Application
{
    public interface IPaymentService
    {
        List<PaymentMethodDTO> GetAllCanUsePaymentMethods();

        WalletDTO GetUserWallet(string userId);
    }
}
