using ApplicationCore.Contracts.Repositories;
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
        private IFavoriteRepository _favoriteRepository;
        private IPurchaseRepository _purchaseRepository;
        private IReviewRepository _reviewRepository;
        private IUserRepository _userRepository;
        public UserService(IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository, IPurchaseRepository purchaseRepository, IUserRepository userRepository)
        {
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
            _purchaseRepository = purchaseRepository;
            _userRepository = userRepository;
        }

        public Task<int> AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMovieReview(int userId, int movieId)
        {
            await _reviewRepository.DeleteReview(userId, movieId);
        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FavoriteRequestModel>> GetAllFavoritesForUser(int userId)
        {
            var favorite = await _favoriteRepository.GetAllFavoritesForUser(userId);
            var movieCards = new List<PurchaseRequestModel>();

            // mapping entities data in to models data
            foreach (var movie in favorite)
                movieCards.Add(new PurchaseRequestModel
                {
                    UserId = userId,
                    MovieId = movie.MovieId,
                    Movie = movie.Movie,
                                        
                });

            return (IEnumerable<FavoriteRequestModel>)movieCards;
        }

        public Task<IEnumerable<FavoriteRequestModel>> GetAllFavoritesForUser()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseRequestModel>> GetAllPurchasesForUser(int userId)
        {
            var purchases = await _purchaseRepository.GetAllPurchasesForUser(userId);
            var movieCards = new List<PurchaseRequestModel>();

            // mapping entities data in to models data
            foreach (var movie in purchases)
                movieCards.Add(new PurchaseRequestModel
                {
                   UserId=userId,
                   MovieId=movie.Id,
                   Movie=movie.Movie,
                   TotalPrice=movie.TotalPrice,
                   PurchaseDateTime=movie.PurchaseDateTime,
                   PurchaseNumber=movie.PurchaseNumber,
                   Id=movie.Id
                });

            return movieCards;
        }

        public async Task<IEnumerable<ReviewRequestModel>> GetAllReviewsByUser(int id)
        {
            var reviews = await _reviewRepository.GetAll();
            var reviewedMovies = reviews.Select(g => new ReviewRequestModel
            {
                MovieId = g.MovieId,
                UserId = g.UserId,
            });
            return reviewedMovies;
        }

        public Task<PurchaseRequestModel> GetPurchasesDetails(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var movieId = purchaseRequest.MovieId;
            //var purchases = await _purchaseRepository.GetAllPurchasesForUser(userId);

            var purchase = new Purchase
            {
                UserId = userId, 
                Id = purchaseRequest.Id,
                Customer=purchaseRequest.Customer,
                MovieId=movieId,
                PurchaseNumber=purchaseRequest.PurchaseNumber,
                PurchaseDateTime=purchaseRequest.PurchaseDateTime,
                TotalPrice=purchaseRequest.TotalPrice,
                                
            };
            var newPurchase = await _purchaseRepository.UpdatePurchase(purchase);
            return true;
        }

        public Task<bool> IsMoviePurchased(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }
    }
}
