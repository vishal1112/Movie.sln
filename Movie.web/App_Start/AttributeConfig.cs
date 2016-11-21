using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.web.App_Start
{
    public class AttributeConfig
    {
        public static void RegisterAttributes(GlobalFilterCollection filters)
        {
            filters.Add(new GlobalExceptionHandlerAttribute());
        }
    }
}