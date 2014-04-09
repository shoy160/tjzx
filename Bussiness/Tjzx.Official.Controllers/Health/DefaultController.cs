using System.Web.Mvc;

namespace Tjzx.Official.Controllers.Health
{
    public class DefaultController:Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "健康管理";
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
