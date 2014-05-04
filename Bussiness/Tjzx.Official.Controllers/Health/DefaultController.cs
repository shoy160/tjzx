using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.Controllers.Health
{
    public class DefaultController:Controller
    {
        [HttpGet]
        [Auth(Type = UserType.Member)]
        public ActionResult Index()
        {
            return View("/Views/Health/Index.cshtml");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("/Views/Health/Login.cshtml");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("/Views/Health/Register.cshtml");
        }
    }
}
