using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Authorization
{
    public class UserAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);

            if(!authorized)
            {
                return false;
            }

            var rd = httpContext.Request.RequestContext.RouteData;

            var id = rd.Values["id"];
            var userName = httpContext.User.Identity.Name;



            return base.AuthorizeCore(httpContext);
        }

    }
}