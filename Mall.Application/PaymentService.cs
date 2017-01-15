using System.Collections.Generic;
using System.Linq;
using Mall.Application.DTO;
using Mall.Domain;

namespace Mall.Application
{
    public class PaymentService : IPaymentService
    {
        public List<PaymentMethodDTO> GetAllCanUsePaymentMethods()
        {
            var paymentMethods = DomainRegistry.PaymentService().GetAllPaymentMethods();
            return paymentMethods.Select(ent => new PaymentMethodDTO
            {
                ID = ent.ID,
                Name = ent.Name
            }).ToList();
        }

        public WalletDTO GetUserWallet(string userId)
        {
            var wallet = DomainRegistry.PaymentService().GetWalletByUserId(userId);
            return new WalletDTO
            {
                AvailableBalance = wallet.AvailableBalance,
                AvailableScore = wallet.AvailableScore
            };
        }
    }
}
