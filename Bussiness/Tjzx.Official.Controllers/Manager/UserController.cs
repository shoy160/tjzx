using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class UserController:BaseController
    {
        [Auth(Role = ManagerRole.Users)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Managers.cshtml");
        }

        public JsonResult Insert()
        {
            return Json(new {});
        }
    }
}
