using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class ConsultingController:BaseController
    {
        [Auth(Role = ManagerRole.Consulting)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Consultings.cshtml");
        }
    }
}
