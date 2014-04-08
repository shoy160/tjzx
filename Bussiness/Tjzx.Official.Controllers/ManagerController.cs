using System.Linq;
using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using System.Text;
using Shoy.Utility;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;
using System;

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
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string userPwd, string vCode)
        {
            if (!Web.VerifyImagePage.IsValidatedCode(vCode))
            {
                return Json(new {state = 0, msg = "验证码错误！"});
            }
            var code = BLL.ViewModels.User.Login(userName, userPwd);
            if (code <= 0)
            {
                return Json(new {state = 0, msg = BLL.ViewModels.User.GetErrorMsg(code)});
            }
            return Json(new {state = 1});
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
            var user = BLL.ViewModels.User.GetUser();
            var mg = new BLL.ViewModels.MenuManager(user.Role);
            var list = mg.GetMenus(parentId);
            return new JsonResult
                {
                    Data = list.Select(t => new {id = t.MenuId, name = t.Name, cls = t.Class, link = t.Link})
                };
        }

        [HttpGet]
        [Auth(Role = ManagerRole.News)]
        public ActionResult News(int page = 0)
        {
            using (var db = new EFDbContext())
            {
                var list = db.Newses.Where(t => t.State == (byte) StateType.Display).Skip(page*15).Take(15).ToList();
                return View(list);
            }
        }

        [HttpPost]
        [Auth(Role = ManagerRole.News)]
        public JsonResult AddNews(string title, int type, string content)
        {
            content = Utils.UrlDecode(content, Encoding.UTF8);
            var user = BLL.ViewModels.User.GetUser();
            using (var db = new EFDbContext())
            {
                var item = new News
                    {
                        Title = title,
                        Type = (byte) type,
                        Content = content,
                        CreateOn = DateTime.Now,
                        State = (byte) StateType.Display,
                        CreatorId = user.UserId,
                        Creator = user.UserName,
                        Author = "未知",
                        Comefrom = "未知"
                    };
                db.Newses.Add(item);
                db.SaveChanges();
            }
            return Json(new {title, type, content});
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
