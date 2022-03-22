using ApplicationCore.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Contracts.Repositories.IRepositories;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
          Task UserPurchaseExist(int id, int movieId);
        Task<IEnumerable<Favorite>> GetAllFavoritesForUser(int userId);
        Task<Favorite> GetUserFavorite(int userId, int movieId);
        Task<Favorite> AddFavorite(Favorite favorite);

        Task<Favorite> DeleteFavorite(Favorite favorite);
        Task<Favorite> UpdateFavorite(Favorite favorite);
    }

}
