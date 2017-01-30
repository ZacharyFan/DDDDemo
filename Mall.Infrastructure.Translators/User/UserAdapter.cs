using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Mall.Domain.ValueObject;

namespace Mall.Infrastructure.Translators.User
{
    public class UserAdapter
    {
        private static readonly UserTranslator _userTranslator = new UserTranslator();
        private static readonly JavaScriptSerializer _javaScriptSerializer = new JavaScriptSerializer();

        public Domain.ValueObject.User GetUser(string userId)
        {
            var url = string.Format("http://www.test.com/user/{0}", userId);
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

        public List<ShippingAddress> GetShippingAddressesByUserId(string userId)
        {
            var url = string.Format("http://www.test.com/user/shippingaddress/getallbyuserid/{0}", userId);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _userTranslator.ToShippingAddresses(strReturn);
                    }
                }

                throw new ApplicationException("获取用户信息请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }

        public void AddNewShippingAddress(ShippingAddress newAddress)
        {
            var url = string.Format("http://www.test.com/user/shippingaddress/add");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var jsonData = _javaScriptSerializer.Serialize(newAddress);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
            httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    
                }

                throw new ApplicationException("添加新收货地址请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }

        public void EditShippingAddress(ShippingAddress editAddress)
        {
            var url = string.Format("http://www.test.com/user/shippingaddress/edit");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var jsonData = _javaScriptSerializer.Serialize(editAddress);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
            httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {

                }

                throw new ApplicationException("编辑收货地址请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }

        public void DeleteShippingAddress(string id)
        {
            var url = string.Format("http://www.test.com/user/shippingaddress/delete/{0}", id);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    return;
                }

                throw new ApplicationException("删除收货地址请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }

        public ShippingAddress GetShippingAddress(string id)
        {
            var url = string.Format("http://www.test.com/user/shippingaddress/get/{0}", id);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        var strReturn = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                        return _userTranslator.ToShippingAddress(strReturn);
                    }
                }

                throw new ApplicationException("删除收货地址请求失败，状态码：" + httpWebResponse.StatusCode.ToString());
            }
        }
    }
}
