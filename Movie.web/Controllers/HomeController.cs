using Movie.web.Models.reqres;
using Movie.web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Movie.web.Controllers
{
    public class HomeController : Controller
    {
        private IMovieService _movieService;
        private ICacheService _cacheService;
        public HomeController(IMovieService movieService, ICacheService cacheService)
        {
            _movieService = movieService;
            _cacheService = cacheService;
        }
        public ActionResult Index()
        {
            return View();
        }


        public  ActionResult SortMovie()
        {
            return View();
        }

    }
}