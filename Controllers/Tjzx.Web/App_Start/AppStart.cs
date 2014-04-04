using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tjzx.Web
{
    public class AppStart
    {
        private static readonly Logger Log = Logger.L<AppStart>();

        public static void Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ExtendConfig.Register();
            Log.I("AppStart");
        }
    }
}
