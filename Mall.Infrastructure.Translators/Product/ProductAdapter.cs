using System;
using System.IO;
using System.Net;
using System.Text;

namespace Mall.Infrastructure.Translators.Product
{
    public class ProductAdapter
    {
        private static readonly ProductTranslator _productTranslator = new ProductTranslator();

        public Domain.ValueObject.Product GetProduct(Guid productId)
        {
            var url = string.Format("http://www.test.com/product/{0}", productId.ToString());
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _productTranslator.ToProduct(strReturn);
                    }
                }

                throw new ApplicationException("获取商品信息请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }
    }
}
