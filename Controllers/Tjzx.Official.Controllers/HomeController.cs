using System.Web.Mvc;

namespace Tjzx.Official.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            return View();
        }
    }
}
