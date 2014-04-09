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
                new {controller = "Default", action = "Index"},
                new {action = "[a-z]{3,}"},
                new[] {"Tjzx.Official.Controllers.Health"}
                );

            routes.MapRoute(
                "ManagerDefault",
                "m/{action}",
                new {controller = "Default", action = "Index"},
                new {action = "[a-z]{3,}"},
                new[] {"Tjzx.Official.Controllers.Manager"}
                );

            routes.MapRoute(
                "Manager",
                "m/{controller}/{action}",
                new {controller = "Default", action = "Index"},
                new {action = "[a-z]{3,}"},
                new[] {"Tjzx.Official.Controllers.Manager"}
                );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}