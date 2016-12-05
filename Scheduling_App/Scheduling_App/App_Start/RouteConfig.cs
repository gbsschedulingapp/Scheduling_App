using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Scheduling_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Url redirect",
            //    url: "{Login}/{returnUrl}",
            //    defaults: new { controller = "User", action = "Login", returnUrl = "/AppServices/Create" }
            //);

            routes.MapRoute(
                name: "Url redirect",
                url: "{Login}",
                defaults: new { controller = "User", action = "Login" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );

        }
    }
}
