using System;
using Mall.Domain.Aggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_CartIdDefault_ThrowArgumentException()
        {
            var cart = new Cart(default(Guid), Guid.NewGuid(), DateTime.Now);
            Assert.AreNotEqual(null, cart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_UserIdDefault_ThrowArgumentException()
        {
            var cart = new Cart(Guid.NewGuid(), default(Guid), DateTime.Now);
            Assert.AreNotEqual(null, cart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_LastChangeTimeDefault_ThrowArgumentException()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), default(DateTime));
            Assert.AreNotEqual(null, cart);
        }

        [TestMethod]
        public void AddCartItem_NotExisted_TotalItemCountIsIncreased()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            Assert.AreEqual(1, cart.TotalItemCount());

            cart.AddCartItem(new Guid("22222222-2222-2222-2222-222222222222"), 1, 100);
            Assert.AreEqual(2, cart.TotalItemCount());
        }

        [TestMethod]
        public void AddCartItem_Existed_TotalItemCountIsNotIncreasedTotalItemNumIsIncreased()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            Assert.AreEqual(1, cart.TotalItemCount());
            Assert.AreEqual(1, cart.TotalItemNum());

            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            Assert.AreEqual(1, cart.TotalItemCount());
            Assert.AreEqual(2, cart.TotalItemNum());
        }
    }
}
