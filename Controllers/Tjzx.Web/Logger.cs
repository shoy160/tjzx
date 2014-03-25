using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Diagnostics;
using System.IO;
using log4net.Config;
using Shoy.Utility;
using System.Web;

namespace Tjzx.Web
{
    public sealed class Logger
    {
        private static ILog _log;

        static Logger()
        {
            if (_log == null)
            {
                FileInfo fi = new FileInfo(Path.Combine(Utils.GetCurrentDir(), "log4net.config"));
                XmlConfigurator.Configure(fi);
                _log = LogManager.GetLogger("tjzx");
            }
        }

        private static string Format(string msg)
        {
            var f = new StackFrame(2, true);
            return string.Format("{4}: {0}, {1}, {2}, {3}",
                f.GetFileName(), f.GetMethod().DeclaringType,
                f.GetFileLineNumber(), f.GetMethod(), msg);
        }

        /// <summary>
        /// 信息类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg)
        {
            if (_log.IsInfoEnabled) _log.Info(Format(msg));
        }

        /// <summary>
        /// 调试类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Debug(string msg)
        {
            if (_log.IsDebugEnabled) _log.Debug(Format(msg));
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Fatal(string msg)
        {
            if (_log.IsFatalEnabled) _log.Fatal(Format(msg));
        }

        /// <summary>
        /// 警告类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Warn(string msg)
        {
            if (_log.IsWarnEnabled) _log.Warn(Format(msg));
        }

        /// <summary>
        /// 错误类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            if (_log.IsErrorEnabled) _log.Error(Format(msg));
        }

        public static void ApplicationError()
        {
            Exception objExp = HttpContext.Current.Server.GetLastError();
            var req = HttpContext.Current.Request;
            _log.Error("<br/><strong>客户机IP</strong>：" + req.UserHostAddress + "<br /><strong>错误地址</strong>：" + req.Url, objExp);
        }
    }
}
