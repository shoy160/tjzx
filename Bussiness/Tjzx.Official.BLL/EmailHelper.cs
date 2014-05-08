using System.Collections.Generic;
using Shoy.Utility;
using Tjzx.BLL.Config;
using Tjzx.Official.BLL.Config;
using Tjzx.BLL;

namespace Tjzx.Official.BLL
{
    public class EmailHelper
    {
        private readonly EmailConfig _email;
        private static EmailHelper _instance;
        private static bool _instanceTag;
        private static readonly object LockObj = new object();
        private readonly Logger _logger = Logger.L<EmailHelper>();

        /// <summary>
        /// 唯一初始化
        /// </summary>
        /// <returns></returns>
        public static EmailHelper Instance()
        {
            if (!_instanceTag)
            {
                lock (LockObj)
                {
                    if (!_instanceTag)
                    {
                        _instance = new EmailHelper();
                        _instanceTag = true;
                    }
                }
            }
            return _instance;
        }

        private EmailHelper()
        {
            var config = ConfigUtils<TjzxConfig>.Instance().Get();
            _email = config.Email;
        }

        /// <summary>
        /// 创建EmailCls
        /// </summary>
        /// <returns></returns>
        private EmailCls CreateHelper()
        {
            if (_email == null)
            {
                _logger.I("缺少email配置文件！");
                return new EmailCls("", "");
            }
            return new EmailCls(_email.SenderEmail, _email.SenderPwd, _email.SenderName, _email.SmtpHost,
                                _email.SmtpPort, _email.UseSsl);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">收件人</param>
        /// <param name="title">主题</param>
        /// <param name="content">内容</param>
        public void Send(string receiver, string title, string content)
        {
            using (var helper = CreateHelper())
            {
                string msg;
                if (!helper.SendEmail(receiver, title, content, out msg))
                    _logger.I(msg);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">收件人</param>
        /// <param name="title">主题</param>
        /// <param name="content">内容</param>
        /// <param name="attactes">附件</param>
        public void Send(string receiver, string title, string content, List<string> attactes)
        {
            using (var helper = CreateHelper())
            {
                string msg;
                if (!helper.SendEmail(receiver, title, content, attactes, true, out msg))
                    _logger.I(msg);
            }
        }
    }
}
