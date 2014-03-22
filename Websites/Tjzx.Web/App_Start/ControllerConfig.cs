using System.Web.Mvc;
using Tjzx.Infrastructure.Factory;

namespace Tjzx.Web
{
    public class ControllerConfig
    {
        /// <summary>
        /// 注册自定义Controller
        /// </summary>
        public static void Register()
        {
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
