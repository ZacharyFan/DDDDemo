using Mall.Domain.SellingPrice.MemberPrice.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_RoleDiscountRelation
    {
        [TestMethod]
        public void CalculateDiscountedPrice_DiscountRateTenPercentOff_Success()
        {
            const decimal ORIGINAL_PRICE = 100;
            var relation = new RoleDiscountRelation("roleId", "roleName", 0.9f);

            var reducePrice = relation.CalculateDiscountedPrice(ORIGINAL_PRICE);
            Assert.AreEqual(10, reducePrice);
        }
    }
}
