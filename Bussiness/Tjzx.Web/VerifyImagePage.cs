using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Security.Cryptography;
using System.Web;
using Shoy.Utility;
using System.IO;

namespace Tjzx.Web
{
    public class VerifyImagePage
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _len;

        public VerifyImagePage(int width, int height, int length)
        {
            _width = width;
            _height = height;
            _len = length;
        }

        public VerifyImagePage()
        {
            var context = HttpContext.Current;
            if (context == null)
                return;
            _width = Utils.StrToInt(context.Request.QueryString["width"], 90);
            _height = Utils.StrToInt(context.Request.QueryString["height"], 30);
            _len = Utils.StrToInt(context.Request.QueryString["length"], 4);
        }

        public static bool IsValidatedCode(string code)
        {
            return IsValidatedCode(code, HttpContext.Current);
        }

        public static bool IsValidatedCode(string code,HttpContext context)
        {
            if (context == null || string.IsNullOrEmpty(code) || context.Session["vcode"] == null)
                return false;
            return context.Session["vcode"].ToString().ToLower().Equals(code.ToLower());
        }

        public byte[] VcodeByte()
        {
            var image = Vcode();
            var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }

        public Bitmap Vcode()
        {
            Color bg = Color.White;
            var vcode = Utils.GetRanStr(_len, false);
            Bitmap image = GenerateImage(vcode, bg, 0);
            var context = HttpContext.Current;
            if (context != null)
            {
                context.Session["vcode"] = vcode;
                context.Session.Timeout = 3;
            }
            return image;
        }

        private static readonly byte[] Randb = new byte[4];
        private static readonly RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

        private static readonly Bitmap Charbmp = new Bitmap(40, 30);

        private static readonly Font[] Fonts =
            {
                new Font("Arial", 16, FontStyle.Regular),
                new Font("Arial", 15, (FontStyle.Bold | FontStyle.Italic))
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
                charg.DrawString(code[i].ToString(CultureInfo.InvariantCulture), Fonts[Next(Fonts.Length - 1)],
                                 drawBrush, new PointF(0, 0));
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
