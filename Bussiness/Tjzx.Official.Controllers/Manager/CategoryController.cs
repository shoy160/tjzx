using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class CategoryController:BaseController
    {
        [Auth(Role = ManagerRole.Package)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Category.cshtml");
        }
    }
}
