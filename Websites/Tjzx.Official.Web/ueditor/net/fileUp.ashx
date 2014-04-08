<%@ WebHandler Language="C#" Class="Tjzx.Official.Web.FileUp" %>
using System;
using System.Web;
using System.Collections;
using Tjzx.Official.BLL;

namespace Tjzx.Official.Web
{
    public class FileUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //上传配置
            const string pathbase = "upload/"; //保存路径


            //上传文件
            var up = new Uploader(context);
            Hashtable info = up.SaveFile(pathbase, UploadType.Attach);

            context.Response.Write("{'state':'" + info["state"] + "','url':'" + info["url"] + "','fileType':'" +
                                   info["currentType"] + "','original':'" + info["originalName"] + "'}");
                //向浏览器返回数据json数据
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