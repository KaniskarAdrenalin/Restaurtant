using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurtant
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Route for Rooms controller
            routes.MapRoute(
                name: "Rooms",
                url: "Rooms/{action}/{id}",
                defaults: new { controller = "Rooms", action = "Index", id = UrlParameter.Optional }
            );

            // Route for Users controller
            routes.MapRoute(
                name: "Users",
                url: "Users/{action}/{id}",
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );

            // Route for Bookings controller
            routes.MapRoute(
                name: "Bookings",
                url: "Bookings/{action}/{id}",
                defaults: new { controller = "Bookings", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
