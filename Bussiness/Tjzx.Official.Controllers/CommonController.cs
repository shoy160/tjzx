
using System;
using System.Web.Mvc;
using Tjzx.Web;
using Tjzx.Official.BLL;
using Tjzx.Official.BLL.Business;

namespace Tjzx.Official.Controllers
{
    public class CommonController : Controller
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

        /// <summary>
        /// 文字转语音
        /// </summary>
        /// <param name="word">待转为语音的文字</param>
        /// <returns>音频播放文件url</returns>
        [HttpPost]
        public JsonResult Speek(string word)
        {
            if (string.IsNullOrEmpty(word))
                return Json(new ResultInfo(0, "文字不能为空！"));
            try
            {
                return Json(new ResultInfo(1, "", new {url = SpeekHelper.Speek(word)}));
            }
            catch (Exception)
            {
                return Json(new ResultInfo(0, "语音异常！"));
            }
        }
    }
}
