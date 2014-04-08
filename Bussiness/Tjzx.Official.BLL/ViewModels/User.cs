using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using Shoy.Utility;
using Shoy.Utility.Extend;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.BLL.ViewModels
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Role { get; set; }
        public string Ticket { get; set; }

        public static string[] ErrorMsg = new[] {"用户名不存在！", "登录密码错误！"};

        public static User GetUser()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return null;
            var cookie = CookieCls.GetValue(FormsAuthentication.FormsCookieName);
            var ticket = FormsAuthentication.Decrypt(cookie);
            if (ticket == null) return null;
            return ticket.UserData.JsonToObject<User>();
        }

        public static string GetErrorMsg(int code)
        {
            code = Math.Abs(code) - 1;
            if (code < ErrorMsg.Length)
                return ErrorMsg[code];
            return "操作异常,请重试！";
        }

        public static int Login(string userName, string userPwd)
        {
            using (var db = new EFDbContext())
            {
                var uItem =
                    db.Managers.SingleOrDefault(t => t.UserName == userName && t.State == (byte) StateType.Display);
                if (uItem == null) return -1;
                if (!uItem.PassWord.Equals(userPwd.Md5(), StringComparison.CurrentCultureIgnoreCase))
                    return -2;
                var tick = Guid.NewGuid().ToString().ToLower().Sub(5, 20, "");
                var user = new User
                    {
                        UserId = uItem.ManagerId,
                        UserName = uItem.UserName,
                        Role = uItem.Role,
                        Ticket = tick
                    };
                var ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddHours(2),
                                                           false, user.ToJson());
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                uItem.Ticket = tick;
                uItem.LastLoginIp = Utils.GetRealIp();
                uItem.LastLoginTime = DateTime.Now;
                db.SaveChanges();
                CookieCls.Set(FormsAuthentication.FormsCookieName, encryptedTicket, CookieCls.GetHour(2));
                return 1;
            }
        }

        public static void LoginOut()
        {
            var url = "return_url".QueryOrForm("");
            CookieCls.Delete(FormsAuthentication.FormsCookieName);
            if (string.IsNullOrEmpty(url) || !Utils.IsUrl(url))
            {
                url = FormsAuthentication.LoginUrl;
            }
            HttpContext.Current.Response.Redirect(url, true);
        }
    }
}
