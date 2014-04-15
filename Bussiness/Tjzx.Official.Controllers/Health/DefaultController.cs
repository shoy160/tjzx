using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.Controllers.Health
{
    public class DefaultController:Controller
    {
        [HttpGet]
        [Auth(Type = UserType.Member)]
        public ActionResult Index()
        {
            return View("/Views/Health/Index.cshtml");
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "登录 - 健康管理";
            return View("/Views/Health/Login.cshtml");
        }
    }
}
