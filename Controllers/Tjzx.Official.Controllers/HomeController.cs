using System.Web.Mvc;
using Tjzx.Official.Controllers.ViewModels;
using Tjzx.Web;

namespace Tjzx.Official.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Logger _logger = Logger.L<HomeController>();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            var config = IndexConfig.Get();
            return View(config);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Title = "关于我们";
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Title = "联系我们";
            return View();
        }

        [HttpGet]
        public ActionResult Packages(int id)
        {
            ViewBag.Title = "体检套餐" + id;
            return View();
        }

        [HttpGet]
        public ActionResult Item(int id)
        {
            ViewBag.Title = "套餐详情";
            return View();
        }

        public ActionResult Health()
        {
            ViewBag.Title = "健康管理";
            return View();
        }

        [HttpGet]
        public ActionResult Reservation()
        {
            ViewBag.Title = "在线预约";
            return View();
        }

        [HttpGet]
        public ActionResult Exchanges()
        {
            ViewBag.Title = "咨询交流";
            return View();
        }

        [HttpGet]
        public ActionResult Overview()
        {
            ViewBag.Title = "中心概况";
            return View();
        }

        [HttpGet]
        public ActionResult News()
        {
            ViewBag.Title = "新闻资讯";
            return View();
        }
    }
}
