using System.Web.Http;
using Tjzx.Web.Formatter;

namespace Tjzx.Web
{
    public class FormatterConfig
    {
        /// <summary>
        /// 注册扩展的dataType
        /// </summary>
        public static void Register()
        {
            //jsonp
            var config = GlobalConfiguration.Configuration;
            config.Formatters.Insert(0, new JsonpMediaTypeFormatter());
        }
    }
}
