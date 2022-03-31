using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShopAPI.Services;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
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
        [Route("purchases")]
        public async Task<IActionResult> Purchases()
        {
            var userId = _currentUser.UserId;
            var purchaseDetails = _purchaseService.GetAllPurchasesForUser(userId);
            return Ok(purchaseDetails);
        }
        [HttpGet]
        [Route("favorites")]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUser.UserId;
            var favoriteDetails = _favoriteService.GetAllFavoritesForUser(userId);
            return Ok(favoriteDetails);          
        }
        [HttpGet]
        [Route("movie-reviews")]
        public async Task<IActionResult> Reviews()
        {
            var userId = _currentUser.UserId;
            var reviewDetails = await _reviewService.GetAllReviewsByUser(userId);
            return Ok(reviewDetails);
        }
        [HttpPost]
        [Route("purchase-movie")]
        public async Task<IActionResult> BuyMovies(int movieId)
        {
            var userId = _currentUser.UserId;

            var moviePrice = await _movieService.GetMoviePrice(movieId);

            var purchaseModel = new PurchaseRequestModel
            {
                MovieId = movieId,
                UserId = userId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = moviePrice,
                PurchaseDateTime = DateTime.UtcNow,
            };
            await _purchaseService.IsMoviePurchased(purchaseModel, userId);
            return RedirectToAction("Purchases");          
        }
    }
}
