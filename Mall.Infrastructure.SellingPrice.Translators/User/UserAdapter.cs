using System;
using System.IO;
using System.Net;
using System.Text;
using Mall.Domain.SellingPrice.MemberPrice.ValueObject;

namespace Mall.Infrastructure.SellingPrice.Translators.User
{
    public class UserAdapter
    {
        private static readonly UserTranslator _userTranslator = new UserTranslator();

        public UserRoleRelation GetUserRoleRelation(string userId)
        {
            var url = string.Format("http://www.test.com/userrolerelation/{0}", userId.ToString());
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _userTranslator.ToUserRoleRelation(strReturn);
                    }
                }

                throw new ApplicationException("获取用户信息请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }
    }
}
