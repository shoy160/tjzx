using System.Web.Mvc;

namespace Tjzx.Official.Controllers
{
    /// <summary>
    /// 后台管理
    /// </summary>
    public class ManagerController:Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username,string password)
        {
            return new JsonResult {Data = new {t = 1}};
        }

        [HttpGet]
        public ActionResult Main()
        {
            return View();
        }
    }
}
