using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emuher.Areas.Admin.Controllers
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var httpCookie = httpContext.Request.Cookies["User"];
            if (httpCookie != null && httpCookie.Value != null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Admin/Home/Login");
            return false;
        }
    }
}