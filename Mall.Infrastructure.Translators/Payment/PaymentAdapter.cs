using System;
using System.IO;
using System.Net;
using System.Text;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.Payment
{
    public class PaymentAdapter
    {
        private static readonly PaymentTranslator _paymentTranslator = new PaymentTranslator();

        public PaymentMethod[] GetAllPaymentMethods()
        {
            var url = string.Format("http://www.test.com/payment/getall");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _paymentTranslator.ToPaymentMethods(strReturn);
                    }
                }

                throw new ApplicationException("获取商品信息请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }

        public Wallet GetWalletByUserId(string userId)
        {
            var url = string.Format("http://www.test.com/payment/getall");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _paymentTranslator.ToWallet(strReturn);
                    }
                }

                throw new ApplicationException("获取商品信息请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }

        public PaymentMethod GetPaymentMethod(string id)
        {
            var url = string.Format("http://www.test.com/payment/get/{0}");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _paymentTranslator.ToPaymentMethod(strReturn);
                    }
                }

                throw new ApplicationException("获取商品信息请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }
    }
}
