using System.Web;
using System.Web.Security;
using Shoy.Utility;
using Shoy.Utility.Extend;
using Tjzx.Web.Dict;

namespace Tjzx.Official.Controllers.ViewModels
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ManagerRole Role { get; set; }

        public static User GetUser()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return null;
            var cookie = CookieCls.GetValue(FormsAuthentication.FormsCookieName);
            var ticket = FormsAuthentication.Decrypt(cookie);
            if (ticket == null) return null;
            return ticket.UserData.JsonToObject<User>();
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
