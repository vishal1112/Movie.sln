using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.web.Models
{
    public class BaseMovieModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Poster { get; set; }
        public MovieType Type { get; set; }
    }

    public class MoviesCollection
    {
        public List<BaseMovieModel> Movies { get; set; }
    }

    public enum MovieType
    {
        movie
    }
}