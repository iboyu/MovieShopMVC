﻿using ApplicationCore.Contracts.Services;
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
        public async Task<IActionResult> Details(int id)
        {
            //movie service with details
            //pass the movie details data to view
            //Data
            //remote database

            //CPU bound operation => calculation PI => Loan calculation, image process
            //I/O bound operation => database calls, file, images, videos

            //Network speed, SQL Server Query performance, Server Memory
            //T1 is just waiting
            var movieDetails = await _movieService.GetMovieDetails(id);

            return View(movieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Genres(int id, int pageSize = 30, int pageNumber = 1)
        {
            var pageMovies = await _movieService.GetMoviesByGenrePagination(id, pageSize, pageNumber);
            return View("PagedMovies", pageMovies);   
        }
    }
}
