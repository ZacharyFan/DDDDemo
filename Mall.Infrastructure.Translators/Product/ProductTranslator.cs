using System.Data;
using Mall.Infrastructure.ResponseHandle;

namespace Mall.Infrastructure.Translators.Product
{
    public class ProductTranslator
    {
        public Domain.ValueObject.Product ToProduct(string jsonData)
        {
            JsonResponseReader reader = new JsonResponseReader(jsonData);
            string productIdstr = reader.GetString("productId");
            string saleName = reader.GetString("saleName");
            string shoppePriceStr = reader.GetString("shoppePrice");
            string salePriceStr = reader.GetString("salePrice");
            string saleDescription = reader.GetString("saleDescription");
            string stockStr = reader.GetString("stock");

            if (productIdstr == null)
                throw new NoNullAllowedException("未能正常解析商品ID");

            if (saleName == null)
                throw new NoNullAllowedException("未能正常解析销售名称");

            decimal shoppePrice;
            if (shoppePriceStr == null || !decimal.TryParse(shoppePriceStr, out shoppePrice))
                throw new NoNullAllowedException("未能正常解析专柜价");

            decimal salePrice;
            if (salePriceStr == null || !decimal.TryParse(salePriceStr, out salePrice))
                throw new NoNullAllowedException("未能正常解析销售价");

            if (saleDescription == null)
                throw new NoNullAllowedException("未能正常解析销售描述");

            int stock;
            if (stockStr == null || !int.TryParse(stockStr, out stock))
                throw new NoNullAllowedException("未能正常解析库存");

            var product = new Domain.ValueObject.Product(productIdstr, saleName, shoppePrice, salePrice, saleDescription, stock);
            return product;
        }
    }
}
