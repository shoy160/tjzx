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
                new {action = "[a-z]+", id = "\\d+"}
                );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}