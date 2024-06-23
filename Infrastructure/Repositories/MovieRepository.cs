using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {

        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            //EF Core or Da[[er
            //they provide both sync and async methods in those libraries
            //get top 30 movies by revenue
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public override async Task<Movie> GetById(int id)
        {
            //first throw ex if no matches found
            //firstOrDefault +++safest+++ return default if no matches
            //single throw ex if 0 or more than 1
            //singleOrDefault throw ex if more than 1, if 0 return default
            //we need to uses Include methods
            var movieDetails = await _dbContext.Movies.Include(m => m.Genres).
                ThenInclude(m => m.Genre).Include(m=>m.MovieCasts).ThenInclude(m=>m.Cast)
                .Include(m => m.Trailers).FirstOrDefaultAsync(m => m.Id == id);

            return movieDetails; 
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            //get total movies count for that genre
            var totalMovieCountByGenre = await _dbContext.MovieGenres.Where(m=>m.GenreId == genreId).CountAsync();

            //get the actual movies from MovieGenre and Movie table
            if(totalMovieCountByGenre == 0)
            {
                throw new Exception("No Movies found for that Genre");
            }

            var movies = await _dbContext.MovieGenres.Where(g => g.GenreId == genreId).Include(m => m.Movie)
                .OrderBy(m => m.Movie)
                .Select(m => new Movie{
                    Id = m.MovieId, 
                    PosterUrl = m.Movie.PosterUrl, 
                    Title = m.Movie.Title
            })
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var pagedMovies = new PagedResultSet<Movie>(movies, pageNumber, pageSize, totalMovieCountByGenre, genreId);


            return pagedMovies;
        }
    }
}

