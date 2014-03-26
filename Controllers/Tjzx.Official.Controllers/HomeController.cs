using System.Linq;
using System.Web.Mvc;

namespace Tjzx.Official.Controllers
{
    public class HomeController:BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            return View(Repository.MedicalPackages.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Title = "关于我们";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "联系我们";
            return View();
        }

        public ActionResult Package()
        {
            ViewBag.Title = "体检套餐";
            return View();
        }

        public ActionResult Reservation()
        {
            ViewBag.Title = "在线预约";
            return View();
        }
    }
}
