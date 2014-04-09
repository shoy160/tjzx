using System.Web.Mvc;
using Tjzx.BLL;

namespace Tjzx.Web
{
    public class BaseController : Controller
    {
        private readonly Logger _logger = Logger.L<BaseController>();

        public BaseController()
        {
            _logger.I("Init Controller");
        }
    }
}
