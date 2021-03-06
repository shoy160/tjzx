﻿using System.Linq;
using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Config;
using Tjzx.Official.BLL.Dict;
using System;

namespace Tjzx.Official.Controllers.Manager
{
    /// <summary>
    /// 后台管理
    /// </summary>
    public class DefaultController:Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("/Views/Manager/Login.cshtml");
        }

        [HttpPost]
        public JsonResult Login(string userName, string userPwd, string vCode)
        {
            if (!Web.VerifyImagePage.IsValidatedCode(vCode))
            {
                return Json(new {state = 0, msg = "验证码错误！", code = "vCode"});
            }
            var code = BLL.User.Login(userName, userPwd);
            if (code <= 0)
            {
                var codes = new[] {"userName", "userPwd", "userName"};
                string codeName = string.Empty;
                int index = Math.Abs(code) - 1;
                if (codes.Length > index)
                    codeName = codes[index];
                return
                    Json(
                        new
                            {
                                state = 0,
                                msg = BLL.User.GetErrorMsg(code),
                                code = codeName
                            });
            }
            return Json(new {state = 1});
        }

        [HttpGet]
        public ActionResult LoginOut()
        {
            return View("/Views/Manager/LoginOut.cshtml");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/Manager/Main.cshtml");
        }

        [HttpPost]
        [Auth]
        public JsonResult Menus(int parentId)
        {
            var user = BLL.User.GetUser();
            var mg = new MenuManager(user.Role);
            var list = mg.GetMenus(parentId);
            return new JsonResult
                {
                    Data =
                        list.Select(
                            t => new {id = t.MenuId, name = t.Name, icon = t.Icon, link = t.Link})
                };
        }

        [ActionName("package")]
        [Auth(Role = ManagerRole.Package)]
        public ActionResult Package()
        {
            return View("/Views/Manager/PackageList.cshtml");
        }
    }
}
