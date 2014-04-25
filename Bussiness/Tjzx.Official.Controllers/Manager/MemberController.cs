using Shoy.Utility.Extend;
using Tjzx.Web;
using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.Controllers.Manager
{
    /// <summary>
    /// 会员管理Controller
    /// </summary>
    public class MemberController : BaseController
    {
        private readonly MemberBusi _busi = new MemberBusi();

        [HttpGet]
        [Auth(Role = ManagerRole.Member)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Members.cshtml");
        }

        /// <summary>
        /// 新增或更新会员
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Member)]
        public JsonResult Insert(MemberInfo info)
        {
            if (info.MemberId > 0)
                return Json(_busi.Update(info));
            return Json(_busi.Insert(info));
        }

        /// <summary>
        /// 会员列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("list")]
        [Auth(Role = ManagerRole.Member)]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        /// <summary>
        /// 会员详细信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Auth(Role = ManagerRole.Member)]
        [ActionName("item")]
        public JsonResult Item(int userId)
        {
            return Json(_busi.Item(userId));
        }

        /// <summary>
        /// 更新会员状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Member)]
        public JsonResult UpdateState(int userId, int state)
        {
            return Json(_busi.UpdateState(userId, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Member)]
        public JsonResult UpdateState(int[] userIds, int state)
        {
            return Json(_busi.UpdateState(userIds, (StateType)state));
        }

        /// <summary>
        /// 删除会员(将状态更新为已删除)
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Member)]
        public JsonResult Delete(int memberId)
        {
            return Json(_busi.UpdateState(memberId, StateType.Delete));
        }

        /// <summary>
        /// 还原会员(将状态更新为隐藏)
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Member)]
        public JsonResult Restore(int memberId)
        {
            return Json(_busi.UpdateState(memberId, StateType.Hidden));
        }
    }
}
