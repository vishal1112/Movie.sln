using Movie.web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.web.Models
{
    public class MovieModel : BaseMovieModel, IComparable
    {
        /// <summary>
        /// future can be converted to enum, as identifying all type of rating type
        /// </summary>
        public string Rated { get; set; }
        public string Released { get; set; }
        public string RunTime { get; set; }
        public MovieGenre Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public int Metascore { get; set; }
        public decimal Rating { get; set; }
        public string Votes { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }
        public string OrderBy { get; set; }
        public Order MovieOrder { get; set; }

        public int CompareTo(object obj)
        {
            MovieModel mModel = obj as MovieModel;
            if (mModel.Price < Price)
            {
                return 1;
            }
            if (mModel.Price > Price)
            {
                return -1;
            }
            return 0;
        }
    }


    [Flags]
    public enum MovieGenre
    {
        Action,
        Adventure,
        Fantasy,
        Romantic
    }
}