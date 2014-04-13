using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class ConsultingController:BaseController
    {
        private readonly ConsultingBusi _busi = new ConsultingBusi();

        [Auth(Role = ManagerRole.Consulting)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Consultings.cshtml");
        }

        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Consulting)]
        public JsonResult Insert(ConsultingInfo info)
        {
            if (info.Id > 0)
                return Json(_busi.Update(info));
            return Json(_busi.Insert(info));
        }

        [HttpPost]
        [ActionName("list")]
        [Auth(Role = ManagerRole.Consulting)]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Consulting)]
        [ActionName("item")]
        public JsonResult Item(int id)
        {
            return Json(_busi.Item(id));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Consulting)]
        public JsonResult UpdateState(int id, int state)
        {
            return Json(_busi.UpdateState(id, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Consulting)]
        public JsonResult UpdateState(int[] ids, int state)
        {
            return Json(_busi.UpdateState(ids, (StateType)state));
        }

        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Consulting)]
        public JsonResult Delete(int id)
        {
            return Json(_busi.UpdateState(id, StateType.Delete));
        }

        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Consulting)]
        public JsonResult Restore(int id)
        {
            return Json(_busi.UpdateState(id, StateType.Hidden));
        }
    }
}
