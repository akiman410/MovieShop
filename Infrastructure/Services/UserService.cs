using ApplicationCore.Contracts.Services;
using ApplicationCore.Enities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Contracts.Repositories.IRepositories;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private IRepository<Favorite> _favoriteRepository;
        private IRepository<Purchase> _purchaseRepository;
        private IRepository<Review> _reviewRepository;

        public UserService(IRepository<Favorite> favoriteRepository, IRepository<Purchase> purchaseRepository, IRepository<Review> reviewRepository)
        {
            _favoriteRepository = favoriteRepository;
            _purchaseRepository = purchaseRepository;
            _reviewRepository = reviewRepository;
        }
        public async Task<IEnumerable<FavoriteRequestModel>> GetAllFavoritesForUser()
        {            
                var favorites = await _favoriteRepository.GetAll();
                var favoriteMovies = favorites.Select(g => new FavoriteRequestModel
                {
                   MovieId = g.MovieId,
                   UserId = g.UserId,
                });
                return favoriteMovies ;            
        }

        public async Task<IEnumerable<PurchaseRequestModel>> GetAllPurchasesForUser()
        {
            var purchases = await _purchaseRepository.GetAll();
            var purchasedMovies = purchases.Select(g => new PurchaseRequestModel
            {
                Id=g.Id,
                UserId=g.UserId,
                MovieId=g.MovieId,
                PurchaseDateTime=g.PurchaseDateTime,
                PurchaseNumber=g.PurchaseNumber,
                TotalPrice=g.TotalPrice,
            });
            return purchasedMovies;
        }

        public async Task<IEnumerable<ReviewRequestModel>> GetAllReviewsByUser()
        {
            var reviews = await _reviewRepository.GetAll();
            var reviewedMovies = reviews.Select(g => new ReviewRequestModel
            {
                MovieId = g.MovieId,
                UserId = g.UserId,
            });
            return reviewedMovies;
        }
    }
}
