using System;

namespace Mall.Domain.FavoritesModule.Entity
{
    public class FavoritesItem
    {
        public string ID { get; private set; }

        public DateTime FavoriteTime { get; private set; }

        public FavoritesItem(string id, DateTime favoriteTime)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");

            if (favoriteTime == default(DateTime))
                throw new ArgumentException("favoriteTime");

            this.ID = id;
            this.FavoriteTime = favoriteTime;
        }
    }
}
