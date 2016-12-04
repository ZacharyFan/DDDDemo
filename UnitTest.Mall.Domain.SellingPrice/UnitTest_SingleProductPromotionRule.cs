using System;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_SingleProductPromotionRule
    {
        [TestMethod]
        public void IsExistedProduct_SameProductId_Success()
        {
            var promotionRule = (SingleProductPromotionRule)new PromotionRuleLimitTimeDiscount("promotionId", "title", "productId", "title", new DateTime(2000, 1, 1), new DateTime(2000, 1, 10), 10);

            var product = promotionRule.GetPromotionContainsProduct();
            Assert.AreNotEqual(null, product);
            Assert.AreEqual(true, promotionRule.IsExistedProduct("productId"));
        }

        [TestMethod]
        public void IsExistedProduct_DifferentProductId_Failure()
        {
            var promotionRule = (SingleProductPromotionRule)new PromotionRuleLimitTimeDiscount("promotionId", "title", "productId", "title", new DateTime(2000, 1, 1), new DateTime(2000, 1, 10), 10);

            var product = promotionRule.GetPromotionContainsProduct();
            Assert.AreNotEqual(null, product);
            Assert.AreEqual(false, promotionRule.IsExistedProduct("productId2"));
        }
    }
}
