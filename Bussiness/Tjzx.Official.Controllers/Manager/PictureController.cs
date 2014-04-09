using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class PictureController:BaseController
    {
        [Auth(Role = ManagerRole.Overview)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Pictures.cshtml");
        }
    }
}
