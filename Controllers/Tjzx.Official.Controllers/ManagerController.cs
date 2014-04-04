using System.Web.Mvc;
using System.Linq;
using System.Web.Security;
using Tjzx.Official.Controllers.ViewModels;
using System;
using System.Web;
using Tjzx.Web.Dict;
using Shoy.Utility.Extend;
using Tjzx.Official.Controllers.Attributes;

namespace Tjzx.Official.Controllers
{
    /// <summary>
    /// 后台管理
    /// </summary>
    public class ManagerController:Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if(!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = new User
                    {
                        UserId = 1001,
                        UserName = "shoy",
                        Role = ManagerRole.Package | ManagerRole.News | ManagerRole.Users
                    };

                var ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddHours(2),
                                                           false, user.ToJson());
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    {
                        Expires = DateTime.Now.AddHours(2)
                    };
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            }
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username,string password)
        {
            return new JsonResult {Data = new {t = 1}};
        }

        [HttpGet]
        public ActionResult LoginOut()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Main()
        {
            return View();
        }

        [HttpPost]
        [Auth]
        public JsonResult Menus(int parentId)
        {
            var user = ViewModels.User.GetUser();
            var mg = new MenuManager(user.Role);
            var list = mg.GetMenus(parentId);
            return new JsonResult
                {
                    Data = list.Select(t => new {id = t.MenuId, name = t.Name, cls = t.Class, link = t.Link})
                };
        }

        [Auth(Role = ManagerRole.News)]
        public ActionResult News()
        {
            return View();
        }

        [Auth(Role = ManagerRole.Package)]
        public ActionResult Category()
        {
            return View();
        }

        [Auth(Role = ManagerRole.Package)]
        public ActionResult PackageList()
        {
            return View();
        }

        [Auth(Role=ManagerRole.Package)]
        public ActionResult Process()
        {
            return View();
        }

        [Auth(Role = ManagerRole.Reservation)]
        public ActionResult Reservations()
        {
            return View();
        }

        [Auth(Role=ManagerRole.Consulting)]
        public ActionResult Consultings()
        {
            return View();
        }

        [Auth(Role=ManagerRole.Overview)]
        public ActionResult Pictures()
        {
            return View();
        }

        [Auth(Role=ManagerRole.Health)]
        public ActionResult Health()
        {
            return View();
        }

        [Auth(Role = ManagerRole.Health)]
        public ActionResult Assess()
        {
            return View();
        }

        [Auth(Role = ManagerRole.Users)]
        public ActionResult Managers()
        {
            return View();
        }
    }
}
