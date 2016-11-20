using System;
using Mall.Domain.Aggregate;
using Mall.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain
{
    [TestClass]
    public class CartItemTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyQuantity_LessZero_ThrowArgumentException()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            var cartItem = cart.GetCartItem(new Guid("11111111-1111-1111-1111-111111111111"));
            Assert.AreNotEqual(null, cartItem);
            Assert.AreEqual(1, cartItem.Quantity);
            cartItem.ModifyQuantity(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyQuantity_EqualsZero_ThrowArgumentException()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            var cartItem = cart.GetCartItem(new Guid("11111111-1111-1111-1111-111111111111"));
            Assert.AreNotEqual(null, cartItem);
            Assert.AreEqual(1, cartItem.Quantity);
            cartItem.ModifyQuantity(0);
        }

        [TestMethod]
        public void ModifyQuantity_MoreZero_Success()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            var cartItem = cart.GetCartItem(new Guid("11111111-1111-1111-1111-111111111111"));
            Assert.AreNotEqual(null, cartItem);
            Assert.AreEqual(1, cartItem.Quantity);
            cartItem.ModifyQuantity(10);
            Assert.AreEqual(10, cartItem.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyPrice_LessZero_ThrowArgumentException()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            var cartItem = cart.GetCartItem(new Guid("11111111-1111-1111-1111-111111111111"));
            Assert.AreNotEqual(null, cartItem);
            Assert.AreEqual(100, cartItem.Price);
            cartItem.ModifyPrice(-1);
        }

        [TestMethod]
        public void ModifyPrice_EqualsZero_Success()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            var cartItem = cart.GetCartItem(new Guid("11111111-1111-1111-1111-111111111111"));
            Assert.AreNotEqual(null, cartItem);
            Assert.AreEqual(100, cartItem.Price);
            cartItem.ModifyPrice(0);
            Assert.AreEqual(0, cartItem.Price);
        }

        [TestMethod]
        public void ModifyPrice_MoreZero_Success()
        {
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            cart.AddCartItem(new Guid("11111111-1111-1111-1111-111111111111"), 1, 100);
            var cartItem = cart.GetCartItem(new Guid("11111111-1111-1111-1111-111111111111"));
            Assert.AreNotEqual(null, cartItem);
            Assert.AreEqual(100, cartItem.Price);
            cartItem.ModifyPrice(10);
            Assert.AreEqual(10, cartItem.Price);
        }
    }
}
