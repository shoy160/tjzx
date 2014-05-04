using System.Web.Mvc;
using Tjzx.BLL;
using Tjzx.BLL.Config;
using Tjzx.Official.BLL;
using Tjzx.Official.BLL.Config;
using Tjzx.Web;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Logger _logger = Logger.L<HomeController>();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            var config = ConfigUtils<IndexConfig>.Instance().Get();
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
        public ActionResult Packages(int id = 0)
        {
            ViewBag.Title = "体检套餐";
            return View();
        }

        [HttpPost]
        [ActionName("package_list")]
        public JsonResult PackageList(int id, int page = 0, int size = 10)
        {
            var busi = new PackageBusi();
            return Json(
                busi.GetList(new SearchInfo
                    {
                        CategoryId = (id <= 0 ? Const.Ignore : id),
                        Page = page,
                        Size = size,
                        State = (byte) StateType.Display
                    })
                );
        }

        [HttpGet]
        public ActionResult Item(int id)
        {
            var busi = new PackageBusi();
            return View(busi.GetItem(id));
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

        [HttpPost]
        [ActionName("AddConsulting")]
        public JsonResult SubmitExchanges(ConsultingInfo info)
        {
            var busi = new ConsultingBusi();
            return Json(busi.Insert(info));
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
            ViewBag.Title = "健康资讯";
            return View();
        }

        [HttpPost]
        [ActionName("news_list")]
        public JsonResult NewsList(int page = 0, int size = 10)
        {
            if (size > 20) size = 20;
            var busi = new NewsBusi();
            return Json(busi.GetDynamicNews(page, size));
        }

        [HttpGet]
        [ActionName("news_item")]
        public ActionResult NewsItem(int id = 0)
        {
            var busi = new NewsBusi();
            busi.UpdateViews(id);
            return View("/Views/Home/NewsItem.cshtml", busi.GetItem(id));
        }
    }
}
