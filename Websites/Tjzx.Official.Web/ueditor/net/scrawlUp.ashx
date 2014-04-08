<%@ WebHandler Language="C#" Class="Tjzx.Official.Web.ScrawlImgUp" %>

using System.Web;
using System.Collections;
using Shoy.Utility;
using Tjzx.Official.BLL;

namespace Tjzx.Official.Web
{
    public class ScrawlImgUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];

            if (action == "tmpImg")
            {
                //上传配置
                const string pathbase = "tmp/"; //保存路径

                //上传图片
                var up = new Uploader(context);
                Hashtable info = up.SaveFile(pathbase);

                HttpContext.Current.Response.Write("<script>parent.ue_callback('" + info["url"] + "','" + info["state"] + "')</script>");//回调函数
            }
            else
            {
                string tmpPath = Utils.GetMapPath("~/upload_tmp/"); //临时图片目录       

                //上传图片
                var up = new Uploader(context);
                Hashtable info = up.SaveScrawl(context.Request["content"], tmpPath);

                //向浏览器返回json数据
                HttpContext.Current.Response.Write("{'url':'" + info["url"] + "',state:'" + info["state"] + "'}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}