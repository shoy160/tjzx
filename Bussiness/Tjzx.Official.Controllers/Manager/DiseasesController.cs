using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.Controllers.Manager
{
    public class DiseasesController:BaseController
    {
        private DiseasesBusi _busi = new DiseasesBusi();
        [HttpGet]
        [Auth(Role = ManagerRole.Diseases)]
        public ActionResult Index()
        {
            return View("/Views/Manager/DiseasesList.cshtml");
        }

        /// <summary>
        /// 新增或更新疾病
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Diseases)]
        public JsonResult Insert(DiseasesInfo info)
        {
            if (info.DiseasesId > 0)
                return Json(_busi.Update(info));
            return Json(_busi.Insert(info));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Diseases)]
        [ActionName("list")]
        public JsonResult GetList(SearchInfo info)
        {
            return Json(_busi.GetList(info));
        }

        /// <summary>
        /// 疾病详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Auth(Role = ManagerRole.Diseases)]
        [ActionName("item")]
        public JsonResult Item(int id)
        {
            return Json(_busi.Item(id));
        }

        /// <summary>
        /// 更新疾病状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Diseases)]
        public JsonResult UpdateState(int userId, int state)
        {
            return Json(_busi.UpdateState(userId, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Diseases)]
        public JsonResult UpdateState(int[] userIds, int state)
        {
            return Json(_busi.UpdateState(userIds, (StateType)state));
        }

        /// <summary>
        /// 删除疾病(将状态更新为已删除)
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Diseases)]
        public JsonResult Delete(int memberId)
        {
            return Json(_busi.UpdateState(memberId, StateType.Delete));
        }

        /// <summary>
        /// 还原疾病(将状态更新为隐藏)
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Diseases)]
        public JsonResult Restore(int memberId)
        {
            return Json(_busi.UpdateState(memberId, StateType.Hidden));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Diseases)]
        [ActionName("department_list")]
        public JsonResult DepartmentList()
        {
            return Json(_busi.GetDepartmentList((int) StateType.Display));
        }
    }
}
