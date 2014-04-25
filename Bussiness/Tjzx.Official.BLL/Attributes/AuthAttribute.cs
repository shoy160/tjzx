using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.Business;

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
            Type = UserType.Manager;
        }

        public AuthAttribute(UserType type)
        {
            Type = type;
        }

        public UserType Type { get; set; }
        public string Users { get; set; }
        public ManagerRole Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                DeelResult(filterContext, "操作需要登录系统，请先登录！");
                return;
            }
            var user = User.GetUser();
            if (user == null || user.Type != Type.GetValue())
            {
                DeelResult(filterContext, "登录已失效，请先登录！");
                return;
            }
            //判断凭证
            if (user.Type == (byte) UserType.Manager)
            {
                var busi = new ManagerBusi();
                var uItem = busi.GetItem(user.UserId);
                if (uItem == null || uItem.Ticket != user.Ticket)
                {
                    DeelResult(filterContext, "登录已失效，请先登录！");
                    return;
                }
            }
            else if (user.Type == (byte) UserType.Member)
            {
                var busi = new MemberBusi();
                var uItem = busi.GetItem(user.UserId);
                if (uItem == null || uItem.Ticket != user.Ticket)
                {
                    DeelResult(filterContext, "登录已失效，请先登录！");
                    return;
                }
            }
            if (string.IsNullOrEmpty(Users) && Role == ManagerRole.None)
            {
                return;
            }
            if (!string.IsNullOrEmpty(Users))
            {
                var users = Users.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                if (!users.Contains(user.UserName))
                {
                    DeelResult(filterContext, "用户权限被限制！");
                    return;
                }
            }
            if (Role != ManagerRole.None)
            {
                if ((user.Role & Role.GetValue()) == 0)
                {
                    DeelResult(filterContext, "权限验证不通过！");
                }
            }
        }

        private void DeelResult(ActionExecutingContext filterContext, string msg)
        {
            var result = new ContentResult();

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                result.Content = new {state = -1, msg}.ToJson();
                filterContext.Result = result;
                return;
            }
            User.RedirectToLogin(Type);
        }
    }
}