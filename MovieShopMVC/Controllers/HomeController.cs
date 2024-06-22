using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        //readonly only can change value in constructor
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //our controllers are very thin/lean
            //most of your logic should come from other dependencies, such as services
            //interfaces
            //void method(int x, IMovieService service);
            //class MovieService : IMovieService{}

            //var movieservice = new MovieService();
            //method(20, movieservice);
            //
            //var movieService = new MovieService();
            //my model data
            var movies = _movieService.GetTop30GrossingMovies();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TopMovies()
        {

            return View("TopMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
