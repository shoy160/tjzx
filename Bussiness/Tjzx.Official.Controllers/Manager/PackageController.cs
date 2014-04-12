using System.Web.Mvc;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class PackageController:BaseController
    {
        private readonly PackageBusi _busi = new PackageBusi();
        [Auth(Role = ManagerRole.Package)]
        public ActionResult Index()
        {
            return View("/Views/Manager/PackageList.cshtml");
        }

        [HttpPost]
        [ActionName("add")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult Insert(PackageInfo info, string sex)
        {
            if (!string.IsNullOrEmpty(sex))
            {
                var sexs = sex.To(new byte[] {});
                foreach (var i in sexs)
                {
                    info.Sex |= i;
                }
            }
            if (info.PackageId > 0)
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
        public JsonResult Item(int packageId)
        {
            return Json(_busi.Item(packageId));
        }

        [HttpPost]
        [ActionName("updateState")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult UpdateState(int packageId, int state)
        {
            return Json(_busi.UpdateState(packageId, (StateType)state));
        }

        [HttpPost]
        [ActionName("updateStates")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult UpdateState(int[] packageIds, int state)
        {
            return Json(_busi.UpdateState(packageIds, (StateType)state));
        }

        [HttpPost]
        [ActionName("delete")]
        [Auth(Role = ManagerRole.Package)]
        public JsonResult Delete(int packageId)
        {
            return Json(_busi.UpdateState(packageId, StateType.Delete));
        }

        [HttpPost]
        [ActionName("restore")]
        [Auth(Role = ManagerRole.Users)]
        public JsonResult Restore(int packageId)
        {
            return Json(_busi.UpdateState(packageId, StateType.Hidden));
        }
    }
}
