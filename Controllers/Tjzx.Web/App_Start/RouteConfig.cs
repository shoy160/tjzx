using System.Web.Mvc;
using System.Web.Routing;

namespace Tjzx.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Home",
                "{action}/{id}",
                new {controller = "Home", action = "Index", id = 0},
                new {action = "[a-z]{3,}", id = "\\d+"}
                );
            routes.MapRoute(
                "Health",
                "h/{action}",
                new {controller = "Health", action = "Index"},
                new {action = "[a-z]{3,}"}
                );

            routes.MapRoute(
                "Manager",
                "m/{action}",
                new { controller = "Manager", action = "Main" },
                new { action = "[a-z]{3,}" }
                );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}