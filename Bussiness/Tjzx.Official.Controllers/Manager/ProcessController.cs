using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Business;

namespace Tjzx.Official.Controllers.Manager
{
    public class ProcessController:BaseController
    {
        private readonly NewsBusi _busi = new NewsBusi();
        [HttpGet]
        [Auth(Role = ManagerRole.Package)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Process.cshtml");
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Package)]
        [ActionName("item")]
        public JsonResult GetItem(int type)
        {
            if (!type.In(NewsType.MedicalProcess.GetValue(), NewsType.Attention.GetValue()))
                return Json(new {state = 0, msg = "无效的类型！"});
            return Json(_busi.GetNonCustomItem((byte) type));
        }

        [HttpPost]
        [Auth(Role = ManagerRole.Package)]
        [ActionName("update")]
        public JsonResult Update(int type, string content)
        {
            if (!type.In(NewsType.MedicalProcess.GetValue(), NewsType.Attention.GetValue()))
                return Json(new {state = 0, msg = "无效的类型！"});
            return Json(_busi.UpdateItem((byte) type, content));
        }
    }
}
