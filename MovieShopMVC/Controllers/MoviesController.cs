using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Details(int id)
        {
            //movie service with details
            //pass the movie details data to view
            var movieDetails = _movieService.GetMovieDetails(id);

            return View(movieDetails);
        }
    }
}
