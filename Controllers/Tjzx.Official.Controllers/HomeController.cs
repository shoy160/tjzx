using System.Linq;
using System.Web.Mvc;
using Tjzx.Official.Models.Abstract;
using Tjzx.Web;

namespace Tjzx.Official.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMedicalPackageRepository _medicalPackages;

        public HomeController(IMedicalPackageRepository repository)
        {
            _medicalPackages = repository;
        }

        private readonly Logger _logger = Logger.L<HomeController>();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            _logger.D("test");
            return View(_medicalPackages.Values.ToList());
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
        public ActionResult Package()
        {
            ViewBag.Title = "体检套餐";
            return View();
        }

        [HttpGet]
        public ActionResult Reservation()
        {
            ViewBag.Title = "在线预约";
            return View();
        }
    }
}
