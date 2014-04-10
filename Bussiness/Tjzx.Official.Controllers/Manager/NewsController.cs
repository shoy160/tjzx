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
        [ActionName("item")]
        public JsonResult Item(int newsId)
        {
            return Json(NewsBusi.Item(newsId));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.News)]
        [ActionName("list")]
        public JsonResult GetNews(SearchInfo info)
        {
            return Json(NewsBusi.GetList(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.News)]
        [ActionName("add")]
        public JsonResult AddNews(NewsInfo info)
        {
            if (info.NewsId > 0)
                return Json(NewsBusi.Update(info));
            return Json(NewsBusi.Insert(info));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.News)]
        public JsonResult UpdateNews(int newsId, int state)
        {
            return Json(NewsBusi.UpdateState(newsId, (StateType) state));
        }

        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.News)]
        public JsonResult Delete(int newsId)
        {
            return Json(NewsBusi.UpdateState(newsId, StateType.Delete));
        }

        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.News)]
        public JsonResult Restore(int newsId)
        {
            return Json(NewsBusi.UpdateState(newsId, StateType.Hidden));
        }
    }
}
