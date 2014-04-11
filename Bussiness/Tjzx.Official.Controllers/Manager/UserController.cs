using System.Web.Mvc;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class UserController : BaseController
    {
        private readonly UserBusi _busi = new UserBusi();

        [Auth(Role = ManagerRole.Users)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Managers.cshtml");
        }

        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Insert(UserInfo info,string roles)
        {
            if (!string.IsNullOrEmpty(roles))
            {
                info.Roles = roles.To(new int[] { });
            }
            if (info.UserId > 0)
                return Json(_busi.Update(info));
            return Json(_busi.Insert(info));
        }

        [HttpPost]
        [ActionName("list")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Users)]
        [ActionName("item")]
        public JsonResult Item(int userId)
        {
            return Json(_busi.Item(userId));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult UpdateState(int userId, int state)
        {
            return Json(_busi.UpdateState(userId, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult UpdateState(int[] userIds, int state)
        {
            return Json(_busi.UpdateState(userIds, (StateType)state));
        }

        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Delete(int userId)
        {
            return Json(_busi.UpdateState(userId, StateType.Delete));
        }

        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Restore(int userId)
        {
            return Json(_busi.UpdateState(userId, StateType.Hidden));
        }
    }
}
