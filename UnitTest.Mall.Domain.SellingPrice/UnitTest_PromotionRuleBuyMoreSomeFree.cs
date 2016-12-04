using System.Collections.Generic;
using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Mall.Domain.SellingPrice.Promotion.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_PromotionRuleBuyMoreSomeFree
    {
        [TestMethod]
        public void CalculateReducePrice_BoughtProductIsNull_ReducePriceZero()
        {
            var promotion = new PromotionRuleBuyMoreSomeFree("promotionId", "title", 20, 15);
            promotion.JoinProduct("productId1", "productName");
            promotion.JoinProduct("productId2", "productName");
            promotion.JoinProduct("productId3", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId1"));
            Assert.AreEqual(true, promotion.IsExistedProduct("productId2"));
            Assert.AreEqual(true, promotion.IsExistedProduct("productId3"));
            var reducePrice = promotion.CalculateReducePrice(null);
            Assert.AreEqual(0, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_LessMeetProductQuantity_ReducePriceZero()
        {
            const int QUANTITY = 1;
            const int MEETQUANTITY = 20;
            const int FREEQUANTITY = 15;
            const decimal UNIT_PRICE_PRODUCT1 = 10;
            const decimal UNIT_PRICE_PRODUCT2 = 20;
            const decimal UNIT_PRICE_PRODUCT3 = 30;
            var promotion = new PromotionRuleBuyMoreSomeFree("promotionId", "title", MEETQUANTITY, FREEQUANTITY);
            promotion.JoinProduct("productId1", "productName");
            promotion.JoinProduct("productId2", "productName");
            promotion.JoinProduct("productId3", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId1"));
            Assert.AreEqual(true, promotion.IsExistedProduct("productId2"));
            Assert.AreEqual(true, promotion.IsExistedProduct("productId3"));
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId1",QUANTITY,UNIT_PRICE_PRODUCT1,0,null,null),
                new BoughtProduct("productId2",QUANTITY,UNIT_PRICE_PRODUCT2,0,null,null),
                new BoughtProduct("productId3",QUANTITY,UNIT_PRICE_PRODUCT3,0,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(0, reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_MoreMeetProductQuantity_HasReducePrice()
        {
            const int QUANTITY = 10;
            const int MEETQUANTITY = 20;
            const int FREEQUANTITY = 15;
            const decimal UNIT_PRICE_PRODUCT1 = 10;
            const decimal UNIT_PRICE_PRODUCT2 = 20;
            const decimal UNIT_PRICE_PRODUCT3 = 30;
            var promotion = new PromotionRuleBuyMoreSomeFree("promotionId", "title", MEETQUANTITY, FREEQUANTITY);
            promotion.JoinProduct("productId1", "productName");
            promotion.JoinProduct("productId2", "productName");
            promotion.JoinProduct("productId3", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId1"));
            Assert.AreEqual(true, promotion.IsExistedProduct("productId2"));
            Assert.AreEqual(true, promotion.IsExistedProduct("productId3"));
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId1",QUANTITY,UNIT_PRICE_PRODUCT1,0,null,null),
                new BoughtProduct("productId2",QUANTITY,UNIT_PRICE_PRODUCT2,0,null,null),
                new BoughtProduct("productId3",QUANTITY,UNIT_PRICE_PRODUCT3,0,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(UNIT_PRICE_PRODUCT1 * QUANTITY + UNIT_PRICE_PRODUCT2 * (FREEQUANTITY - QUANTITY), reducePrice);
        }

        [TestMethod]
        public void CalculateReducePrice_EqualsMeetProductQuantity_HasReducePrice()
        {
            const int MEETQUANTITY = 20;
            const int FREEQUANTITY = 15;
            const decimal UNIT_PRICE_PRODUCT = 10;
            var promotion = new PromotionRuleBuyMoreSomeFree("promotionId", "title", MEETQUANTITY, FREEQUANTITY);
            promotion.JoinProduct("productId1", "productName");
            Assert.AreEqual(true, promotion.IsExistedProduct("productId1"));
            List<BoughtProduct> products = new List<BoughtProduct>
            {
                new BoughtProduct("productId1",MEETQUANTITY,UNIT_PRICE_PRODUCT,0,null,null)
            };
            var reducePrice = promotion.CalculateReducePrice(products);
            Assert.AreEqual(UNIT_PRICE_PRODUCT * FREEQUANTITY, reducePrice);
        }
    }
}
