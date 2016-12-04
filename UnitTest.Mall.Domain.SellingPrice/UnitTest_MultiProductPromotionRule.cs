using Mall.Domain.SellingPrice.Promotion.Aggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_MultiProductPromotionRule
    {
        [TestMethod]
        public void JoinProduct_SameProduct_NoAffect()
        {
            var promotion = (MultiProductPromotionRule)new PromotionRuleMeetReduction("promotionId", "title", 100, 10);
            promotion.JoinProduct("productId", "productName");
            var containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(1, containsProducts.Count);

            promotion.JoinProduct("productId", "productName");
            containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(1, containsProducts.Count);
        }

        [TestMethod]
        public void JoinProduct_DifferentProduct_Success()
        {
            var promotion = (MultiProductPromotionRule)new PromotionRuleMeetReduction("promotionId", "title", 100, 10);
            promotion.JoinProduct("productId1", "productName");
            var containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(1, containsProducts.Count);

            promotion.JoinProduct("productId2", "productName");
            containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(2, containsProducts.Count);
        }

        [TestMethod]
        public void RemoveProduct_NotExist_NoAffect()
        {
            var promotion = (MultiProductPromotionRule)new PromotionRuleMeetReduction("promotionId", "title", 100, 10);
            promotion.JoinProduct("productId1", "productName");
            var containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(true, promotion.IsExistedProduct("productId1"));

            promotion.RemoveProduct("productId2");
            containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(true, promotion.IsExistedProduct("productId1"));
        }

        [TestMethod]
        public void RemoveProduct_Exist_Success()
        {
            var promotion = (MultiProductPromotionRule)new PromotionRuleMeetReduction("promotionId", "title", 100, 10);
            promotion.JoinProduct("productId1", "productName");
            var containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(true, promotion.IsExistedProduct("productId1"));

            promotion.RemoveProduct("productId1");
            containsProducts = promotion.GetPromotionContainsProducts();
            Assert.AreNotEqual(null, containsProducts);
            Assert.AreEqual(false, promotion.IsExistedProduct("productId1"));
        }
    }
}
