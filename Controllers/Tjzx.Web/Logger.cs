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
        static Logger()
        {
            FileInfo fi = new FileInfo(Path.Combine(Utils.GetCurrentDir(), "bin\\log4net.config"));
            XmlConfigurator.Configure(fi);
        }

        /// <summary>
        /// 信息类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Info<T>(string msg)
        where T : class
        {
            var log = LogManager.GetLogger(typeof(T));
            if (log.IsInfoEnabled) log.Info(msg);
        }

        /// <summary>
        /// 调试类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Debug<T>(string msg)
            where T:class
        {
            var log = LogManager.GetLogger(typeof(T));
            if (log.IsDebugEnabled) log.Debug(msg);
        }        

        /// <summary>
        /// 警告类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Warn<T>(string msg)
            where T:class
        {
            var log = LogManager.GetLogger(typeof(T));
            if (log.IsWarnEnabled) log.Warn(msg);
        }

        /// <summary>
        /// 错误类日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Error<T>(string msg)
            where T:class
        {
            var log = LogManager.GetLogger(typeof(T));
            if (log.IsErrorEnabled) log.Error(msg);
        }

        public static void Error<T>(string msg, Exception ex)
            where T:class
        {
            var log = LogManager.GetLogger(typeof(T));
            if (log.IsErrorEnabled) log.Error(msg, ex);
        }

        /// <summary>
        /// 致命错误日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Fatal<T>(string msg)
            where T:class
        {
            var log = LogManager.GetLogger(typeof(T));
            if (log.IsFatalEnabled) log.Fatal(msg);
        }

        public static void Fatal<T>(string msg, Exception ex)
            where T:class
        {
            var log = LogManager.GetLogger(typeof(T));
            if (log.IsFatalEnabled) log.Fatal(msg, ex);
        }

        public static void ApplicationError<T>()
            where T:class
        {
            var log = LogManager.GetLogger(typeof(T));
            Exception objExp = HttpContext.Current.Server.GetLastError();
            var req = HttpContext.Current.Request;
            log.Error(string.Format("客户机IP：{0}\r\n错误地址：{1}",
                req.UserHostAddress, req.Url), objExp);
        }
    }
}
