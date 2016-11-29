using System;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_PromotionRuleLimitTimeDiscount
    {
        [TestMethod]
        public void CalculateReducePrice_NotExistProductId_ReducePriceZero()
        {
            var promotion = new PromotionRuleLimitTimeDiscount("promotionId", "title", new DateTime(2016, 11, 11),
                new DateTime(2016, 11, 13), 10);

            promotion.JoinProduct("productId", "productName");
            var reducePrice = promotion.CalculateReducePrice("productId1", 100, DateTime.Now);
            Assert.AreEqual(0, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_ExistProductIdInvalidDateTime_ReducePriceZero()
        {
            var promotion = new PromotionRuleLimitTimeDiscount("promotionId", "title", new DateTime(2016, 11, 11),
                new DateTime(2016, 11, 13), 10);

            promotion.JoinProduct("productId", "productName");
            var reducePrice = promotion.CalculateReducePrice("productId", 100, new DateTime(2016, 11, 10));
            Assert.AreEqual(0, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_ExistProductIdValidDateTime_ReducePriceZero()
        {
            const decimal ORIGINAL_PRICE = 100;
            const decimal DISCOUNTED_PRICE = 10;
            var promotion = new PromotionRuleLimitTimeDiscount("promotionId", "title", new DateTime(2016, 11, 11),
                new DateTime(2016, 11, 13), DISCOUNTED_PRICE);

            promotion.JoinProduct("productId", "productName");
            var reducePrice = promotion.CalculateReducePrice("productId", ORIGINAL_PRICE, new DateTime(2016, 11, 12));
            Assert.AreEqual(ORIGINAL_PRICE - DISCOUNTED_PRICE, reducePrice);
        }
    }
}
