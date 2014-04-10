using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.BLL.Attributes
{
    /// <summary>
    /// 身份验证
    /// </summary>
    public class AuthAttribute:ActionFilterAttribute
    {
        public AuthAttribute(string users = "", ManagerRole role = ManagerRole.None)
        {
            Users = users;
            Role = role;
        }

        public string Users { get; set; }
        public ManagerRole Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = new ContentResult();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                result.Content = new { state = -1, msg = "操作需要登录系统，请先登录！" }.ToJson();
                filterContext.Result = result;
                User.RedirectToLogin();
            }
            else
            {
                if (string.IsNullOrEmpty(Users) && Role == ManagerRole.None)
                {
                    return;
                }
                var user = User.GetUser();
                if (user == null)
                {
                    result.Content = new {state = 0, msg = "身份验证不通过！"}.ToJson();
                    filterContext.Result = result;
                    return;
                }

                if (!string.IsNullOrEmpty(Users))
                {
                    var users = Users.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    if (!users.Contains(user.UserName))
                    {
                        result.Content = new { state = 0, msg = "用户权限被限制！" }.ToJson();
                        filterContext.Result = result;
                        return;
                    }
                }
                if (Role != ManagerRole.None)
                {
                    if ((user.Role & Role.GetValue()) == 0)
                    {
                        result.Content = new {state = 0, msg = "权限验证不通过！"}.ToJson();
                        filterContext.Result = result;
                    }
                }
            }
        }
    }
}