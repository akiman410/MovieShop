using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        public MoviesController(IMovieService movieService, ICurrentUser currentUser, IUserService userService)
        {
            _movieService = movieService;
            _currentUser = currentUser;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // Call Movie Service with Details and pass the movie details data to Views
            // Data
            // Remote Database    

            // CPU bound operation => PI => Loan callcuator, image pro
            // I/O bound operation => database calls, file, images, videos

            // Network speed, SQL Server => Query , Server Memory
            // T1 is just waiting

            //if (_currentUser.IsAuthenticated)
            //{
            //    var moviePurchase = await _userService.IsMoviePurchased(id);
            //    ViewBag.MoviePurchase = true;
            //}
            //else
            //{
            //    ViewBag.MoviePurchase = false;
            //}
         
            var movieDetails = await _movieService.GetMovieDetails(id);
            return View(movieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Genres(int id, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieService.GetMoviesByGenrePagination(id, pageSize, pageNumber);
            return View("PagedMovies", pagedMovies);
        }

        [HttpGet]
        public IActionResult TopMovies()
        {
            return View();
        }
    }
}
