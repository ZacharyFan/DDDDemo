using System;
using System.Collections.Generic;
using System.Data;
using Mall.Domain.ValueObject;
using Mall.Infrastructure.ResponseHandle;

namespace Mall.Infrastructure.Translators.User
{
    public class UserTranslator
    {
        public Domain.ValueObject.User ToUser(string jsonData)
        {
            JsonResponseReader reader = new JsonResponseReader(jsonData);
            string userIdstr = reader.GetString("userId");
            string userName = reader.GetString("userName");
            string availableBalanceStr = reader.GetString("availableBalance");

            if (userIdstr == null)
                throw new NoNullAllowedException("未能正常解析用户ID");

            if (userName == null)
                throw new NoNullAllowedException("未能正常解析用户名");

            decimal availableBalance;
            if (availableBalanceStr == null || !decimal.TryParse(availableBalanceStr, out availableBalance))
                throw new NoNullAllowedException("未能正常解析可用余额");

            var user = new Domain.ValueObject.User(userIdstr, userName, availableBalance);
            return user;
        }

        public List<ShippingAddress> ToShippingAddresses(string jsonData)
        {
            throw new NotImplementedException();
        }

        public ShippingAddress ToShippingAddress(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}
