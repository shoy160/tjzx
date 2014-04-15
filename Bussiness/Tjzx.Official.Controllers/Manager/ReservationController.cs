using System.Web.Mvc;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.Controllers.Manager
{
    public class ReservationController:BaseController
    {
        private readonly ReservationBusi _busi = new ReservationBusi();

        [Auth(Role = ManagerRole.Reservation)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Reservations.cshtml");
        }

        [HttpPost]
        [ActionName("update")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult Update(ReservationInfo info)
        {
            if (info.ReservationId <= 0) return Json(new {state = 0, msg = ""});
            return Json(_busi.Update(info));
        }

        [HttpPost]
        [ActionName("list")]
        [Auth(Role = ManagerRole.Reservation)]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Reservation)]
        [ActionName("item")]
        public JsonResult Item(int packageId)
        {
            return Json(_busi.Item(packageId));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Reservation)]
        public JsonResult UpdateState(int packageId, int state)
        {
            return Json(_busi.UpdateState(packageId, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Reservation)]
        public JsonResult UpdateState(int[] packageIds, int state)
        {
            return Json(_busi.UpdateState(packageIds, (StateType)state));
        }

        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Reservation)]
        public JsonResult Delete(int packageId)
        {
            return Json(_busi.UpdateState(packageId, StateType.Delete));
        }

        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Reservation)]
        public JsonResult Restore(int packageId)
        {
            return Json(_busi.UpdateState(packageId, StateType.Hidden));
        }
    }
}
