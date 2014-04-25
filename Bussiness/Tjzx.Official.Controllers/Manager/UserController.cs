using System.Web.Mvc;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    /// <summary>
    /// 管理员Controller
    /// </summary>
    public class UserController : BaseController
    {
        private readonly ManagerBusi _busi = new ManagerBusi();

        [Auth(Role = ManagerRole.Users)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Managers.cshtml");
        }

        /// <summary>
        /// 新增或更新管理员
        /// </summary>
        /// <param name="info"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Insert(ManagerInfo info,string roles)
        {
            if (!string.IsNullOrEmpty(roles))
            {
                info.Roles = roles.To(new int[] { });
            }
            if (info.UserId > 0)
                return Json(_busi.Update(info));
            return Json(_busi.Insert(info));
        }

        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("list")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        /// <summary>
        /// 管理员详细信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Auth(Role = ManagerRole.Users)]
        [ActionName("item")]
        public JsonResult Item(int userId)
        {
            return Json(_busi.Item(userId));
        }

        /// <summary>
        /// 更新管理员状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 删除管理员(将状态更新为已删除)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Delete(int userId)
        {
            return Json(_busi.UpdateState(userId, StateType.Delete));
        }

        /// <summary>
        /// 还原管理员(将状态更新为隐藏)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Restore(int userId)
        {
            return Json(_busi.UpdateState(userId, StateType.Hidden));
        }
    }
}
