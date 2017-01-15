using System;
using System.Data;
using Mall.Domain.ValueObject;
using Mall.Infrastructure.ResponseHandle;

namespace Mall.Infrastructure.Translators.Payment
{
    public class PaymentTranslator
    {
        public PaymentMethod[] ToPaymentMethods(string jsonData)
        {
            throw new NotImplementedException();
        }

        public Wallet ToWallet(string jsonData)
        {
            JsonResponseReader reader = new JsonResponseReader(jsonData);
            string idstr = reader.GetString("id");
            string userId = reader.GetString("userId");
            string availableBalanceStr = reader.GetString("availableBalance");
            string availableScoreStr = reader.GetString("availableScore");

            if (idstr == null)
                throw new NoNullAllowedException("未能正常解析钱包ID");

            if (userId == null)
                throw new NoNullAllowedException("未能正常解析用户ID");

            decimal availableBalance;
            if (availableBalanceStr == null || !decimal.TryParse(availableBalanceStr, out availableBalance))
                throw new NoNullAllowedException("未能正常解析可用余额");

            int availableScore;
            if (availableScoreStr == null || !int.TryParse(availableScoreStr, out availableScore))
                throw new NoNullAllowedException("未能正常解析可用积分");

            var wallet = new Wallet(idstr, userId, availableBalance, availableScore);
            return wallet;
        }
    }
}
