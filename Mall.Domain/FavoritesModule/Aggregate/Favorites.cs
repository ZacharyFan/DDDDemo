using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mall.Domain.CartModule.Entity;
using Mall.Domain.FavoritesModule.Entity;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.FavoritesModule.Aggregate
{
    public class Favorites : AggregateRoot
    {
        private readonly List<FavoritesItem> _favoritesItems;

        public string UserId { get; private set; }

        public Favorites(string userId, IEnumerable<FavoritesItem> favoritesItems)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            this.UserId = userId;
            this._favoritesItems = new List<FavoritesItem>();

            if (favoritesItems != null && favoritesItems.Any())
            {
                foreach (var favoritesItem in favoritesItems)
                {
                    AddFavoritesItem(favoritesItem);
                }
            }
        }

        public ReadOnlyCollection<FavoritesItem> GetFavoritesItems()
        {
            return this._favoritesItems.AsReadOnly();
        }

        public void AddFavoritesItem(CartItem cartItem)
        {
            var favoritesItem = new FavoritesItem(cartItem.ID, DateTime.Now);
            AddFavoritesItem(favoritesItem);
        }

        public void RemoveFavoritesItem(string id)
        {
            var favoritesItem = this._favoritesItems.SingleOrDefault(ent => ent.ID == id);
            if (favoritesItem == null)
                return;

            this._favoritesItems.Remove(favoritesItem);
        }

        private void AddFavoritesItem(FavoritesItem favoritesItem)
        {
            if (this._favoritesItems.Any(ent => ent.ID == favoritesItem.ID))
                return;
            this._favoritesItems.Add(favoritesItem);
        }
    }
}
