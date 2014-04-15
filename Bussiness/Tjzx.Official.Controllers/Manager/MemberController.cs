using Tjzx.Web;
using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.Controllers.Manager
{
    public class MemberController : BaseController
    {
        [HttpGet]
        [Auth(Role = ManagerRole.Health)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Members.cshtml");
        }
    }
}
