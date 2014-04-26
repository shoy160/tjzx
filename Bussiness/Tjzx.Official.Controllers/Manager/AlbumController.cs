using System.Web.Mvc;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.BLL.Business;
using Tjzx.BLL;
using System.Web;
using Tjzx.Official.BLL;

namespace Tjzx.Official.Controllers.Manager
{
    public class AlbumController:BaseController
    {
        private readonly AlbumBusi _busi = new AlbumBusi();

        private readonly Logger _logger = Logger.L<AlbumController>();

        [Auth(Role = ManagerRole.Overview)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Albums.cshtml");
        }

        [HttpPost]
        [ActionName("groups")]
        [Auth(Role = ManagerRole.Overview)]
        public JsonResult GetGroups()
        {
            var busi = new AlbumGroupBusi();
            var info = new SearchInfo
                {
                    State = (byte) StateType.Display
                };
            return Json(busi.GetList(info));
        }

        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Overview)]
        public JsonResult Insert(AlbumInfo info)
        {
            if (info.AlbumId > 0)
                return Json(_busi.Update(info));
            return Json(_busi.Insert(info));
        }

        [HttpPost]
        [ActionName("list")]
        [Auth(Role = ManagerRole.Overview)]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Overview)]
        [ActionName("item")]
        public JsonResult Item(int albumId = 0)
        {
            return Json(_busi.Item(albumId));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Overview)]
        public JsonResult UpdateState(int albumId, int state)
        {
            return Json(_busi.UpdateState(albumId, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Overview)]
        public JsonResult UpdateState(int[] albumIds, int state)
        {
            return Json(_busi.UpdateState(albumIds, (StateType)state));
        }

        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Overview)]
        public JsonResult Delete(int albumId)
        {
            return Json(_busi.UpdateState(albumId, StateType.Delete));
        }

        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Overview)]
        public JsonResult Restore(int albumId)
        {
            return Json(_busi.UpdateState(albumId, StateType.Hidden));
        }

        /// <summary>
        /// 首图上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("uploadImage")]
        public JsonResult UploadImage(HttpPostedFileBase fileData, int albumId = 0)
        {
            _logger.I(albumId + "");
            var uploader = new Uploader(System.Web.HttpContext.Current);
            return Json(uploader.SaveAlbumImage(albumId));
        }
    }
}
