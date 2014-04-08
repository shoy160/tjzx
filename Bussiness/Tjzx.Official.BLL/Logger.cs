using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using log4net;
using log4net.Config;
using Shoy.Utility;

namespace Tjzx.Official.BLL
{
    public sealed class Logger
    {
        static Logger()
        {
            var fi = new FileInfo(Path.Combine(Utils.GetCurrentDir(), "bin\\log4net.config"));
            XmlConfigurator.Configure(fi);
        }

        private readonly ILog _logger;

        private Logger(ILog logger)
        {
            _logger = logger;
        }

        public static Logger L<T>()
        {
            var logger = LogManager.GetLogger(typeof (T));
            return new Logger(logger);
        }

        public static Logger L(string name = "")
        {
            var logger = LogManager.GetLogger(name);
            return new Logger(logger);
        }

        private static string Format(string msg)
        {
            string ip = "", url = "";
            if (HttpContext.Current != null)
            {
                try
                {
                    ip = Utils.GetRealIp();
                    url = HttpContext.Current.Request.Url.ToString();
                }catch{}
            }
            var f = new StackFrame(2, true);
            return string.Format("IP:{6}{5}URL:{7}{5}Method:{1}({0}) {3}:{2}{5}Msg:{4}{5}",
                                 f.GetFileName(), f.GetMethod().DeclaringType,
                                 f.GetFileLineNumber(), f.GetMethod().Name, msg, Environment.NewLine,
                                 ip, url);
        }

        /// <summary>
        /// 信息类日志
        /// </summary>
        /// <param name="msg"></param>
        public void I(string msg)
        {
            if (_logger.IsInfoEnabled) _logger.Info(Format(msg));
        }

        /// <summary>
        /// 调试类日志
        /// </summary>
        /// <param name="msg"></param>
        public void D(string msg)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(Format(msg));
        }

        /// <summary>
        /// 警告类日志
        /// </summary>
        /// <param name="msg"></param>
        public void W(string msg)
        {
            if (_logger.IsWarnEnabled) _logger.Warn(Format(msg));
        }

        /// <summary>
        /// 错误类日志
        /// </summary>
        /// <param name="msg"></param>
        public void E(string msg)
        {
            if (_logger.IsErrorEnabled) _logger.Error(Format(msg));
        }

        public void E(string msg, Exception ex)
        {
            if (_logger.IsErrorEnabled) _logger.Error(Format(msg), ex);
        }

        /// <summary>
        /// 致命错误日志
        /// </summary>
        /// <param name="msg"></param>
        public void F(string msg)
        {
            if (_logger.IsFatalEnabled) _logger.Fatal(Format(msg));
        }

        public void F(string msg, Exception ex)
        {
            if (_logger.IsFatalEnabled) _logger.Fatal(Format(msg), ex);
        }

        public static void ApplicationError<T>()
            where T : class
        {
            var log = LogManager.GetLogger(typeof (T));
            Exception objExp = HttpContext.Current.Server.GetLastError();
            log.Error(Format("ApplicationError"), objExp);
        }
    }
}
