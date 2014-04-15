using System.Web.Mvc;
using Tjzx.Web;

namespace Tjzx.Official.Controllers
{
    public class CommonController:Controller
    {
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VCode()
        {
            var code = new VerifyImagePage();
            return File(code.VcodeByte(), "image/jpeg");
        }
    }
}
