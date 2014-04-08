<%@ WebHandler  Language="C#"  Class="Tjzx.Official.Web.GetContent" %>

using System.Web;

namespace Tjzx.Official.Web
{
    public class GetContent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //获取数据
            string content = context.Server.HtmlEncode(context.Request.Form["myEditor"]);


            //存入数据库或者其他操作
            //-------------

            //显示
            context.Response.Write("<script src='../ueditor.parse.js' type='text/javascript'></script>");
            context.Response.Write(

                "<script>uParse('.content',{" +
                      "'rootPath': '../'" +
                  "})" +
                "</script>");

            context.Response.Write("第1个编辑器的值");
            context.Response.Write("<div class='content'>" + context.Server.HtmlDecode(content) + "</div>");

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