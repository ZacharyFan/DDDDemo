using System;
using Mall.Domain.FavoritesModule.Aggregate;
using Mall.Domain.IRepositories;

namespace Mall.Infrastructure.Repositories
{
    public class FavoritesSqlServerRepository : IFavoritesRepository
    {
        public string NextIdentity()
        {
            throw new NotImplementedException();
        }

        public void Save(Favorites aggregate)
        {
            throw new NotImplementedException();
        }

        public Favorites GetByIdentity(string identity)
        {
            throw new NotImplementedException();
        }

        public Favorites GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
