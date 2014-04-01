using System;
using System.IO;
using System.Web;
using log4net;
using log4net.Config;
using Shoy.Utility;

namespace Tjzx.Web
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

        /// <summary>
        /// 信息类日志
        /// </summary>
        /// <param name="msg"></param>
        public void I(string msg)
        {
            if (_logger.IsInfoEnabled) _logger.Info(msg);
        }

        /// <summary>
        /// 调试类日志
        /// </summary>
        /// <param name="msg"></param>
        public void D(string msg)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(msg);
        }

        /// <summary>
        /// 警告类日志
        /// </summary>
        /// <param name="msg"></param>
        public void W(string msg)
        {
            if (_logger.IsWarnEnabled) _logger.Warn(msg);
        }

        /// <summary>
        /// 错误类日志
        /// </summary>
        /// <param name="msg"></param>
        public void E(string msg)
        {
            if (_logger.IsErrorEnabled) _logger.Error(msg);
        }

        public void E(string msg, Exception ex)
        {
            if (_logger.IsErrorEnabled) _logger.Error(msg, ex);
        }

        /// <summary>
        /// 致命错误日志
        /// </summary>
        /// <param name="msg"></param>
        public void F(string msg)
        {
            if (_logger.IsFatalEnabled) _logger.Fatal(msg);
        }

        public void F(string msg, Exception ex)
        {
            if (_logger.IsFatalEnabled) _logger.Fatal(msg, ex);
        }

        public static void ApplicationError<T>()
            where T : class
        {
            var log = LogManager.GetLogger(typeof (T));
            Exception objExp = HttpContext.Current.Server.GetLastError();
            var req = HttpContext.Current.Request;
            log.Error(string.Format("客户机IP：{0}\r\n错误地址：{1}",
                                    req.UserHostAddress, req.Url), objExp);
        }
    }
}
