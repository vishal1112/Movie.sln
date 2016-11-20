using Movie.web.Models;
using Movie.web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Movie.web.Common;

namespace Movie.web.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieService _movieService;
        private ICacheService _cacheService;
        public MoviesController(IMovieService movieService, ICacheService cacheService)
        {
            _movieService = movieService;
            _cacheService = cacheService;
        }


        public ActionResult Search()
        {
            return View();
        }

        public async Task<ActionResult> SearchMovie(int id, string field)
        {
            var responseCarrier = await _movieService.GetMovieListDetail(_cacheService);
            IEnumerable<MovieModel> model = null;
            if (responseCarrier.Status)
            {
                model = (List<MovieModel>)responseCarrier.PayLoad;
                if (model != null)
                {
                    if (_cacheService.IsCached("MyMovies"))
                    {
                        _cacheService.DeleteCache("MyMovies");
                    }
                    _cacheService.WriteCache("MyMovies", model, 5);
                }
            }
            if (model == null)
            {
                if (_cacheService.IsCached("MyMovies"))
                {
                    model = _cacheService.ReadCache<List<MovieModel>>("MyMovies");
                }
            }

            model = sortMovie(id, field, model.ToList<MovieModel>());
            return PartialView("MoviesView", model);
        }

        private IEnumerable<MovieModel> sortMovie(int id, string field, List<MovieModel> model)
        {
            if (string.IsNullOrEmpty(field))
            {
                field = "Price";
            }
            Order sortOrder = Order.Ascending;
            if (id > 0)
            {
                sortOrder = Order.Descending;
            }
            return MovieSorter.Sort_List<MovieModel>(sortOrder, field, model);
        }
    }
}