﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
//    [Table("Movies")]
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Overview { get; set; } = null!;
        public string Tagline { get; set; } = null!;
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; } = null!;
        public string TmdbUrl { get; set; } = null!;
        public string PosterUrl { get; set; } = null!;
        public string BackdropUrl { get; set; } = null!;
        public string OriginalLanguage { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }

        public decimal? Rating { get; set; }

        //navigation property is gonna be collection of trailers
        public ICollection<Trailer> Trailers { get; set; }
        
        public ICollection<MovieGenre>Genres { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
