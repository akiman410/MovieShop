using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {

        Task<IEnumerable<PurchaseRequestModel>> GetAllPurchasesForUser(int userId);
        Task<IEnumerable<FavoriteRequestModel>>  GetAllFavoritesForUser(int userId);
        Task<IEnumerable<ReviewRequestModel>> GetAllReviewsByUser(int userId);

        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseModel, int userId);
     
        Task<PurchaseRequestModel> GetPurchasesDetails(int userId, int movieId);
        Task<int> AddFavorite(FavoriteRequestModel favoriteRequest);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task<bool> FavoriteExists(int id, int movieId);
        
        Task AddMovieReview(ReviewRequestModel reviewRequest);
        Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);
        
    }
}
