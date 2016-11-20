using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ErrorOccurred()
        {
            if (Request.QueryString != null)
            {
                var message = Request.QueryString["Msg"].ToString();
                ViewBag.ErrorMessage = message;
            }
            return View();
        }
    }
}