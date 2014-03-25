using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Diagnostics;

namespace Tjzx.Web
{
    public sealed class Logger
    {
        private static ILog _log;

        static Logger()
        {
            if (_log == null)
                _log = LogManager.GetLogger("tjzx");
        }

        private static string Format(string msg)
        {
            var f = new StackFrame(2, true);
            return string.Format("{4}: {0}, {1}, {2}, {3}",
                f.GetFileName(), f.GetMethod().DeclaringType,
                f.GetFileLineNumber(), f.GetMethod(), msg);
        }

        public static void Info(string msg)
        {
            if (_log.IsInfoEnabled) _log.Info(Format(msg));
        }

        public static void Debug(string msg)
        {
            if (_log.IsDebugEnabled) _log.Debug(Format(msg));
        }

        public static void Fatal(string msg)
        {
            if (_log.IsFatalEnabled) _log.Fatal(Format(msg));
        }

        public static void Warn(string msg)
        {
            if (_log.IsWarnEnabled) _log.Warn(Format(msg));
        }

        public static void Error(string msg)
        {
            if (_log.IsErrorEnabled) _log.Error(Format(msg));
        }
    }
}
