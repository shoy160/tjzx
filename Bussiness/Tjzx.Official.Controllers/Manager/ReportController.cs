using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class ReportController:BaseController
    {
        [HttpGet]
        [Auth(Role = ManagerRole.Report)]
        public ActionResult Index()
        {
            return View("~/Views/Manager/Reports.cshtml");
        }
    }
}
