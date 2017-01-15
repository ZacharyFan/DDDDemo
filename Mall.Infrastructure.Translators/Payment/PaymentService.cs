using System.Collections.Generic;
using System.Linq;
using Mall.Domain.IRemoteServices;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.Payment
{
    public class PaymentService : IPaymentService
    {
        private static readonly PaymentAdapter _paymentAdapter = new PaymentAdapter();

        public List<PaymentMethod> GetAllPaymentMethods()
        {
            return _paymentAdapter.GetAllPaymentMethods().ToList();
        }

        public Wallet GetWalletByUserId(string userId)
        {
            return _paymentAdapter.GetWalletByUserId(userId);
        }
    }
}
