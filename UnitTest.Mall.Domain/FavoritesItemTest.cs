using System;
using Mall.Domain.FavoritesModule.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Mall.Domain
{
    [TestClass]
    public class FavoritesItemTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_IdDefault_ThrowArgumentNullException()
        {
            var favoritesItem = new FavoritesItem(default(string), DateTime.Now);
            Assert.AreNotEqual(null, favoritesItem);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_FavoriteTimeDefault_ThrowArgumentNullException()
        {
            var favoritesItem = new FavoritesItem("id", default(DateTime));
            Assert.AreNotEqual(null, favoritesItem);
        }
    }
}
