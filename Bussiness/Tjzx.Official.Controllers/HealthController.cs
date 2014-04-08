using System.Web.Mvc;
using System.Security.Principal;

namespace Tjzx.Official.Controllers
{
    public class HealthController:Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "健康管理";
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "登录 - 健康管理";
            return View();
        }
    }
}
