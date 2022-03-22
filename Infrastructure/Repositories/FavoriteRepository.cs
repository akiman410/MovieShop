using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Enities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Favorite>>GetAllFavoritesForUser(int userId)
        {
            var favoriteDetail = await _dbContext.Favorites.Where(p => p.UserId == userId).ToListAsync();
            return favoriteDetail;
        }

        public async Task<Favorite> GetUserFavorite(int userId, int movieId)
        {
            var favoriteDetail = await _dbContext.Favorites.Where(p => p.UserId == userId && p.MovieId == movieId).FirstOrDefaultAsync();
            return favoriteDetail;
        }

        public async Task<Favorite> AddFavorite(Favorite favorite)
        {
            _dbContext.Favorites.Add(favorite);
            await _dbContext.SaveChangesAsync();
            return favorite;
        }

        public async Task<Favorite> DeleteFavorite(Favorite favorite)
        {
            _dbContext.Favorites.Remove(favorite);
            await _dbContext.SaveChangesAsync();
            return favorite;
        }

        public Task<Favorite> UpdateFavorite(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public Task UserPurchaseExist(int id, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
