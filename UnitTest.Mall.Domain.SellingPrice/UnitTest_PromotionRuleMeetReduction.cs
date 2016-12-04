using System.Collections.Generic;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Mall.Domain.SellingPrice.Promotion.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_PromotionRuleMeetReduction
    {
        [TestMethod]
        public void CalculateReducePrice_LessMeetPrice_ReducePriceZero()
        {
            var promotion = new PromotionRuleMeetReduction("promotionId", "title", 10, 10);
            promotion.JoinProduct("productId", "productName");
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId",1,5,1,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(0, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_MoreMeetPrice_HasReducePrice()
        {
            var promotion = new PromotionRuleMeetReduction("promotionId", "title", 10, 10);
            promotion.JoinProduct("productId", "productName");
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId",1,11,1,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(10, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_EqualsMeetPrice_HasReducePrice()
        {
            var promotion = new PromotionRuleMeetReduction("promotionId", "title", 10, 10);
            promotion.JoinProduct("productId", "productName");
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId",1,11,1,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(10, reducePrice);
        }
    }
}
