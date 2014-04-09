using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class NewsController : BaseController
    {
        [HttpGet]
        [Auth(Role = ManagerRole.News)]
        public ActionResult Index(int page = 0)
        {
            return View("/Views/Manager/News.cshtml");
        }

        [HttpPost]
        [Auth(Role = ManagerRole.News)]
        [ActionName("list")]
        public JsonResult GetNews(int type = -1, int state = -1, int page = 0, int size = 15)
        {
            if (type == -1) type = Const.Ignore;
            if (state == -1) state = Const.Ignore;
            return Json(NewsUtils.GetList((byte) type, (byte) state, page, size));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.News)]
        [ActionName("add")]
        public JsonResult AddNews(NewsInfo info)
        {
            return Json(NewsUtils.Insert(info));
        }

        [HttpPost]
        [ActionName("update")]
        [Auth(Role = ManagerRole.News)]
        public JsonResult UpdateNews(NewsInfo info)
        {
            return Json(NewsUtils.Update(info));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.News)]
        public JsonResult UpdateNews(int newsId, int state)
        {
            return Json(NewsUtils.UpdateState(newsId, (StateType) state));
        }
    }
}
