using System.Web.Mvc;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Config;
using Tjzx.BLL.Config;
using Tjzx.Official.BLL.Business;

namespace Tjzx.Official.Controllers.Manager
{
    public class HomeConfigController:BaseController
    {
        private IndexConfigBusi _busi = new IndexConfigBusi();

        [HttpGet]
        [Auth(Role = ManagerRole.HomeConfig)]
        public ActionResult Index()
        {
            var config = ConfigUtils<IndexConfig>.Instance().Get();
            return View("~/Views/Manager/HomeConfig.cshtml", config);
        }

        [HttpPost]
        [Auth(Role = ManagerRole.HomeConfig)]
        [ActionName("update_navigation")]
        public JsonResult UpdateNavigation(Navigation info)
        {
            return Json(_busi.UpdateNavigation(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.HomeConfig)]
        [ActionName("update_slider")]
        public JsonResult UpdateSlider(Slider info)
        {
            return Json(_busi.UpdateSlider(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.HomeConfig)]
        [ActionName("update_category")]
        public JsonResult UpdateCategory(Category info, int id)
        {
            info.CategoryId = id;
            return Json(_busi.UpdateCategory(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.HomeConfig)]
        [ActionName("update_friendsLink")]
        public JsonResult UpdateFriendsLink(WordLink info)
        {
            return Json(_busi.UpdateFriendsLink(info));
        }
    }
}
