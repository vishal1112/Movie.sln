using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.web.App_Start
{
    public class GlobalExceptionHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
            filterContext.Result = new RedirectResult(@"/Error/ErrorOccurred?Msg=" + "OOPS! Something went wrong .Our support team is looking into it please re-try.");
        }
    }
}