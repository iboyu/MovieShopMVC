using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
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

        public IEnumerable<Movie> GetTop30RevenueMovies()
        {
            //get top 30 movies by revenue
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30);
            return movies;
        }

        public override Movie GetById(int id)
        {
            //first throw ex if no matches found
            //firstOrDefault +++safest+++ return default if no matches
            //single throw ex if 0 or more than 1
            //singleOrDefault throw ex if more than 1, if 0 return default
            //we need to uses Include methods
            var movieDetails = _dbContext.Movies.Include(m => m.Genres).
                ThenInclude(m => m.Genre).Include(m=>m.MovieCasts).ThenInclude(m=>m.Cast)
                .Include(m => m.Trailers).FirstOrDefault(m => m.Id == id);

            return movieDetails; 
        }
    }
}

