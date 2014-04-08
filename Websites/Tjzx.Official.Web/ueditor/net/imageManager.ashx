<%@ WebHandler Language="C#" Class="Tjzx.Official.Web.ImageManager" %>
using System;
using System.Web;
using Tjzx.Official.BLL;

namespace Tjzx.Official.Web
{
    public class ImageManager : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string action = context.Server.HtmlEncode(context.Request["action"]);

            if (action == "get")
            {
                var uploader = new Uploader(context);
                var files = uploader.GetFiles();
                context.Response.Write(String.Join("ue_separate_ue", files));
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