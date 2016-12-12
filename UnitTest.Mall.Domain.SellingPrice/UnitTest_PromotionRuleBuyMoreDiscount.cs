using System;
using System.Collections.Generic;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Mall.Domain.SellingPrice.Promotion.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_PromotionRuleBuyMoreDiscount
    {
        [TestMethod]
        public void CalculateReducePrice_BoughtProductIsNull_ReducePriceZero()
        {
            var promotion = new PromotionRuleBuyMoreDiscount("promotionId", "title", 10, 5);
            promotion.JoinProduct("productId", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId"));
            var reducePrice = promotion.CalculateReducePrice(null);
            Assert.AreEqual(0, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_LessMeetProductQuantity_ReducePriceZero()
        {
            var promotion = new PromotionRuleBuyMoreDiscount("promotionId", "title", 10, 5);
            promotion.JoinProduct("productId", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId"));
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId",1,12,0,0,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(0, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_MoreMeetProductQuantity_HasReducePrice()
        {
            const int QUANTITY = 11;
            const decimal UNIT_PRICE = 12;
            var promotion = new PromotionRuleBuyMoreDiscount("promotionId", "title", 10, 5);
            promotion.JoinProduct("productId", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId"));
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId",QUANTITY,UNIT_PRICE,0,0,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(UNIT_PRICE * QUANTITY * 0.5M, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_EqualsMeetProductQuantity_HasReducePrice()
        {
            const int QUANTITY = 10;
            const decimal UNIT_PRICE = 12;
            var promotion = new PromotionRuleBuyMoreDiscount("promotionId", "title", QUANTITY, 5);
            promotion.JoinProduct("productId", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId"));
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId",QUANTITY,UNIT_PRICE,0,0,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(UNIT_PRICE * QUANTITY * 0.5M, reducePrice);
        }
    }
}
