using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using Shoy.Utility;

namespace Tjzx.Web
{
    public class VerifyImagePage : Page
    {
        private int _width;
        private int _height;
        private int _len;

        public static bool IsValidatedCode(HttpContext context, string code)
        {
            if (context == null || string.IsNullOrEmpty(code) || context.Session["vcode"] == null)
                return false;
            return context.Session["vcode"].ToString().ToLower().Equals(code.ToLower());
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        override protected void OnInit(EventArgs e)
        {
            //
            base.OnInit(e);
            var context = HttpContext.Current;
            if (context == null)
                return;
            _width = Utils.StrToInt(HttpContext.Current.Request.QueryString["w"], 90);
            _height = Utils.StrToInt(HttpContext.Current.Request.QueryString["h"], 30);
            _len = Utils.StrToInt(HttpContext.Current.Request.QueryString["l"], 4);
            Color bg = Color.White;
            var vcode = Utils.GetRanStr(_len, false);
            Bitmap image = GenerateImage(vcode, bg, 0);
            Session["vcode"] = vcode;
            Session.Timeout = 3;
            context.Response.ContentType = "image/jpeg";
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }

        private static readonly byte[] Randb = new byte[4];
        private static readonly RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

        private static readonly Bitmap Charbmp = new Bitmap(40, 30);

        private static readonly Font[] Fonts = {
                                                   new Font(new FontFamily("Arial"), 16, FontStyle.Regular),
                                                   new Font(new FontFamily("Arial"), 16, FontStyle.Regular),
                                                   new Font(new FontFamily("Arial"), 16, FontStyle.Regular),
                                                   new Font(new FontFamily("Arial"), 16, FontStyle.Regular)
                                               };
        /// <summary>
        /// 获得下一个随机数
        /// </summary>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        private static int Next(int max)
        {
            Rand.GetBytes(Randb);
            int value = BitConverter.ToInt32(Randb, 0);
            value = value % (max + 1);
            if (value < 0)
                value = -value;
            return value;
        }

        /// <summary>
        /// 获得下一个随机数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        private static int Next(int min, int max)
        {
            int value = Next(max - min) + min;
            return value;
        }

        #region IVerifyImage 成员

        private Bitmap GenerateImage(string code, Color bgcolor, int textcolor)
        {
            var bitmap = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.Clear(bgcolor);

            int fixedNumber = textcolor == 2 ? 60 : 0;
            var linePen =
                new Pen(Color.FromArgb(Next(230) + fixedNumber, Next(250) + fixedNumber, Next(250) + fixedNumber), 1);

            var drawBrush = new SolidBrush(Color.FromArgb(Next(100), Next(100), Next(100)));
            for (int i = 0; i < 3; i++)
            {
                g.DrawArc(linePen, Next(20) - 10, Next(20) - 10, Next(_width) + 10, Next(_height) + 10, Next(-100, 100), Next(-200, 200));
            }

            Graphics charg = Graphics.FromImage(Charbmp);

            float charx = -18;
            for (int i = 0; i < code.Length; i++)
            {
                charg.Clear(Color.Transparent);
                drawBrush.Color = Color.FromArgb(Next(230), Next(255), Next(255));
                charx = charx + 18 + Next(5);
                var drawPoint = new PointF(charx, 2.0F);
                charg.DrawString(code[i].ToString(CultureInfo.InvariantCulture), Fonts[Next(Fonts.Length - 1)], drawBrush, new PointF(0, 0));
                g.DrawImage(Charbmp, drawPoint);
            }

            drawBrush.Dispose();
            g.Dispose();
            charg.Dispose();

            return bitmap;
        }

        #endregion
    }
}
