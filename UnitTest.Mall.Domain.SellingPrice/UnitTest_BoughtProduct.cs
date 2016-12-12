using System;
using Mall.Domain.SellingPrice.Promotion.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain.SellingPrice
{
    [TestClass]
    public class UnitTest_BoughtProduct
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeReducePrice_LessZero_Failure()
        {
            var boughtProduct = new BoughtProduct("productId", 1, 100, 0, 0, null, null);
            boughtProduct.ChangeReducePrice(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeReducePrice_MoreUnitPrice_Failure()
        {
            var boughtProduct = new BoughtProduct("productId", 1, 100, 0, 0, null, null);
            boughtProduct.ChangeReducePrice(110);
        }

        [TestMethod]
        public void ChangeReducePrice_Ten_Success()
        {
            const decimal REDUCE_PRICE = 10;
            var boughtProduct = new BoughtProduct("productId", 1, 100, 0, 0, null, null);
            var newBoughtProduct = boughtProduct.ChangeReducePrice(REDUCE_PRICE);
            Assert.AreNotEqual(boughtProduct, newBoughtProduct);
            Assert.AreEqual(REDUCE_PRICE, newBoughtProduct.ReducePrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeReducePriceByMemberPrice_LessZero_Failure()
        {
            var boughtProduct = new BoughtProduct("productId", 1, 100, 0, 0, null, null);
            boughtProduct.ChangeReducePriceByMemberPrice(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeReducePriceByMemberPrice_MoreUnitPrice_Failure()
        {
            var boughtProduct = new BoughtProduct("productId", 1, 100, 0, 0, null, null);
            boughtProduct.ChangeReducePriceByMemberPrice(110);
        }

        [TestMethod]
        public void ChangeReducePriceByMemberPrice_Ten_Success()
        {
            const decimal REDUCE_PRICE = 10;
            var boughtProduct = new BoughtProduct("productId", 1, 100, 0, 0, null, null);
            var newBoughtProduct = boughtProduct.ChangeReducePriceByMemberPrice(REDUCE_PRICE);
            Assert.AreNotEqual(boughtProduct, newBoughtProduct);
            Assert.AreEqual(REDUCE_PRICE, newBoughtProduct.ReducePriceByMemberPrice);
        }
    }
}
