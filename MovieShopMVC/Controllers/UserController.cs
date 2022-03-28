using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using System.Security.Claims;
using MovieShopMVC.Services;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.Models;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserService _purchaseService;
        private readonly IUserService _favoriteService;
        private readonly IUserService _reviewService;
        private readonly IMovieService _movieService;
        public UserController(ICurrentUser currentUser, IUserService purchaseService, IUserService favoriteService, IUserService reviewService, IMovieService movieService)
        {
            _currentUser = currentUser;
            _purchaseService = purchaseService;
            _favoriteService = favoriteService;
            _reviewService = reviewService;
            _movieService = movieService;
        }

        [HttpGet]
        
        public async Task<IActionResult> Purchases()
        {
            // Method needs to verify whether  user is logged in
            //{
            var userId = _currentUser.UserId;
            //}
            //get the user id to verify
            //send the user id to the database to get al the movies the user purchased.
            // user cookie based authentication
            var purchaseDetails = await _purchaseService.GetAllPurchasesForUser(userId);
            return View(purchaseDetails);
        }
      
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUser.UserId;
            var favoriteDetails = await _favoriteService.GetAllFavoritesForUser(userId);
            return View(favoriteDetails);
        }
        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            var userId = _currentUser.UserId;
            var reviewDetails = await _reviewService.GetAllReviewsByUser(userId);
            return View(reviewDetails);
        }
        [HttpPost]
        public async Task<IActionResult> BuyMovies(int movieId)
        {
            var userId = _currentUser.UserId;

            var moviePrice = await _movieService.GetMoviePrice(movieId);

            var purchaseModel = new PurchaseRequestModel
            {
                MovieId = movieId,
                UserId=userId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = moviePrice,
                PurchaseDateTime= DateTime.UtcNow,
            };
                 await _purchaseService.IsMoviePurchased(purchaseModel, userId);
            return RedirectToAction("Purchases");
        }

        [HttpPost]
        public async Task<IActionResult> FavoriteMovie()
        {
            var userId = _currentUser.UserId;

            var favoriteDetails = await _favoriteService.GetAllFavoritesForUser(userId);
            return View(favoriteDetails);
        }

        [HttpPost]
        public async Task<IActionResult> ReviewMovie()
        {
            var userId = _currentUser.UserId;

            var reviewDetails = await _reviewService.GetAllReviewsByUser(userId);
            return View(reviewDetails);
        }
    }
}
