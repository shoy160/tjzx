using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.Controllers.Manager
{
    public class CategoryController:BaseController
    {
        private readonly CategoryBusi _busi = new CategoryBusi();
        [Auth(Role = ManagerRole.Package)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Category.cshtml");
        }

        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult Insert(CategoryInfo info)
        {
            if (info.CateId > 0)
                return Json(_busi.Update(info));
            return Json(_busi.Insert(info));
        }

        [HttpPost]
        [ActionName("list")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Package)]
        [ActionName("item")]
        public JsonResult Item(int cateId)
        {
            return Json(_busi.Item(cateId));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult UpdateState(int cateId, int state)
        {
            return Json(_busi.UpdateState(cateId, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult UpdateState(int[] cateIds, int state)
        {
            return Json(_busi.UpdateState(cateIds, (StateType)state));
        }

        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult Delete(int cateId)
        {
            return Json(_busi.UpdateState(cateId, StateType.Delete));
        }

        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Restore(int cateId)
        {
            return Json(_busi.UpdateState(cateId, StateType.Hidden));
        }
    }
}
