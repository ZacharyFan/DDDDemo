using Mall.Domain.FavoritesModule.Aggregate;
using Mall.Infrastructure.DomainCore;

namespace Mall.Domain.IRepositories
{
    public interface IFavoritesRepository : IRepository<Favorites>
    {
        Favorites GetByUserId(string userId);
    }
}
