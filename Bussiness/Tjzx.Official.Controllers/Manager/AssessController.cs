using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class AssessController:BaseController
    {
        [Auth(Role = ManagerRole.Health)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Assess.cshtml");
        }
    }
}
