using System.Web.Mvc;
using System.Linq;
using System.Web.Security;
using Tjzx.Official.Controllers.ViewModels;
using System;
using System.Web;

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
            
            {
                var ticket = new FormsAuthenticationTicket(1, "shoy", DateTime.Now, DateTime.Now.AddHours(2), false,
                                                           "roles=admin");
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
        [Authorize]
        public ActionResult Main()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public JsonResult Menus(int parentId)
        {
            var userRole = 0x2 | 0x20 | 0x40;
            var mg = new MenuManager(userRole);
            var list = mg.GetMenus(parentId);
            return new JsonResult
                {
                    Data = list.Select(t => new {id = t.MenuId, name = t.Name, cls = t.Class, link = t.Link})
                };
        }

        public ActionResult PackageList()
        {
            return View();
        }
    }
}
