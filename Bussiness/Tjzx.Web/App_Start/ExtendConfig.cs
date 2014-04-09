using System.Web.Mvc;
using Tjzx.Web.Resolver;

namespace Tjzx.Web
{
    public class ExtendConfig
    {
        /// <summary>
        /// 注册扩展项
        /// </summary>
        public static void Register()
        {
            //DependencyInit();
        }

        /// <summary>
        /// 注册自定义Ninject 依赖项
        /// </summary>
        private static void DependencyInit()
        {
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
        }
    }
}
