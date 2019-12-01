﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BitirmeProjesi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "JoinGroup",
                url: "Group/JoinGroup/{groupid}/{uid}",
                defaults: new { controller = "Group", action = "JoinGroup", groupid = UrlParameter.Optional, uid = UrlParameter.Optional }
                );





        }
    }
}
