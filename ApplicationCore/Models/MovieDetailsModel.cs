﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }

        public decimal? Rating { get; set; }
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string? ImdbUrl { get; set; }
        public string? TmdbUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }

        //list of genres
        public List<GenreModel> Genres { get; set; }
        //list of casts
        public List<CastModel> Casts { get; set; }
        //list of trailers
        public List<TrailerModel> Trailers { get; set; }
    }
}
