<%@ WebHandler Language="C#" Class="Tjzx.Official.Web.ImageUp" %>

using System;
using System.Linq;
using System.Web;
using System.Collections;
using Tjzx.Official.BLL;
using Shoy.Utility.Extend;

namespace Tjzx.Official.Web
{
    public class ImageUp : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var dirs = Uploader.GetDirectories();
            if (!String.IsNullOrEmpty(context.Request.QueryString["fetch"]))
            {
                context.Response.AddHeader("Content-Type", "text/javascript;charset=utf-8");
                context.Response.Write(String.Format("updateSavePath([{0}]);",
                                                     String.Join(", ", dirs.Select(x => "\"" + x + "\""))));
                return;
            }

            context.Response.ContentType = "text/plain";


            //上传图片
            var up = new Uploader(context);

            string path = "dir".Form("");
            if (String.IsNullOrEmpty(path))
            {
                path = dirs[0];
            }
            else if (dirs.Count(x => x == path) == 0)
            {
                context.Response.Write("{ 'state' : '非法上传目录' }");
                return;
            }

            Hashtable info = up.SaveFile(path + '/');

            string title = "pictitle".Form(""); //获取图片描述
            string oriName = "fileName".Form("").Split(',')[1]; //获取原始文件名

            HttpContext.Current.Response.Write("{'url':'" + info["url"] + "','title':'" + title + "','original':'" +
                                               oriName + "','state':'" + info["state"] + "'}"); //向浏览器返回数据json数据
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