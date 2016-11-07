using System;
using System.IO;
using System.Net;
using System.Text;

namespace Mall.Infrastructure.Translators.User
{
    public class UserAdapter
    {
        private static readonly UserTranslator _userTranslator = new UserTranslator();

        public Domain.ValueObject.User GetUser(Guid userId)
        {
            var url = string.Format("http://www.test.com/user/{0}", userId.ToString());
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _userTranslator.ToUser(strReturn);
                    }
                }

                throw new ApplicationException("获取用户信息请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }
    }
}
