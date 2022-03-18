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
        public async Task<Favorite> GetAllFavoritesForUser(int userId)
        {
            var favorites = await _dbContext.Favorites.FirstOrDefaultAsync(u => u.MovieId == userId);
            return favorites;
        }
    }
}
