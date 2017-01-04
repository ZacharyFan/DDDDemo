using System;
using Mall.Domain.CartModule.Aggregate;
using Mall.Domain.CartModule.Entity;
using Mall.Domain.FavoritesModule.Aggregate;
using Mall.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain
{
    [TestClass]
    public class FavoritesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_UserIdDefault_ThrowArgumentNullException()
        {
            var favorites = new Favorites(default(string), null);
            Assert.AreNotEqual(null, favorites);
        }

        public void AddFavoritesItem_NotExist_Success()
        {
            var favorites = new Favorites("id", null);
            Assert.AreNotEqual(null, favorites);
            Assert.AreEqual(0, favorites.GetFavoritesItems().Count);

            var cart = new Cart(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now);
            cart.AddCartItem(new Product("11111111-1111-1111-1111-111111111111", "saleName", 200, 100, "saleDescription", int.MaxValue), 1);
            var cartItem = cart.GetCartItem("11111111-1111-1111-1111-111111111111");

            favorites.AddFavoritesItem(cartItem);
            Assert.AreEqual(1, favorites.GetFavoritesItems().Count);
        }

        public void AddFavoritesItem_Exist_NotChange()
        {
            var favorites = new Favorites("id", null);
            Assert.AreNotEqual(null, favorites);
            Assert.AreEqual(0, favorites.GetFavoritesItems().Count);

            var cart = new Cart(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now);
            cart.AddCartItem(new Product("11111111-1111-1111-1111-111111111111", "saleName", 200, 100, "saleDescription", int.MaxValue), 1);
            var cartItem = cart.GetCartItem("11111111-1111-1111-1111-111111111111");

            favorites.AddFavoritesItem(cartItem);
            Assert.AreEqual(1, favorites.GetFavoritesItems().Count);

            favorites.AddFavoritesItem(cartItem);
            Assert.AreEqual(1, favorites.GetFavoritesItems().Count);
        }

        public void RemoveFavoritesItem_NotExist_NotChange()
        {
            var favorites = new Favorites("id", null);
            Assert.AreNotEqual(null, favorites);
            Assert.AreEqual(0, favorites.GetFavoritesItems().Count);

            var cart = new Cart(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now);
            cart.AddCartItem(new Product("11111111-1111-1111-1111-111111111111", "saleName", 200, 100, "saleDescription", int.MaxValue), 1);
            var cartItem = cart.GetCartItem("11111111-1111-1111-1111-111111111111");

            favorites.AddFavoritesItem(cartItem);
            Assert.AreEqual(1, favorites.GetFavoritesItems().Count);

            favorites.RemoveFavoritesItem("22222222-2222-2222-2222-222222222222");
            Assert.AreEqual(1, favorites.GetFavoritesItems().Count);
        }

        public void RemoveFavoritesItem_Exist_Success()
        {
            var favorites = new Favorites("id", null);
            Assert.AreNotEqual(null, favorites);
            Assert.AreEqual(0, favorites.GetFavoritesItems().Count);

            var cart = new Cart(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now);
            cart.AddCartItem(new Product("11111111-1111-1111-1111-111111111111", "saleName", 200, 100, "saleDescription", int.MaxValue), 1);
            var cartItem = cart.GetCartItem("11111111-1111-1111-1111-111111111111");

            favorites.AddFavoritesItem(cartItem);
            Assert.AreEqual(1, favorites.GetFavoritesItems().Count);

            favorites.RemoveFavoritesItem("11111111-1111-1111-1111-111111111111");
            Assert.AreEqual(0, favorites.GetFavoritesItems().Count);
        }
    }
}
