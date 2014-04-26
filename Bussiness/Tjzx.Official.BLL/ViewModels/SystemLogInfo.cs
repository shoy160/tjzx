using System;

namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 系统日志业务类
    /// </summary>
    public class SystemLogInfo : InfoBase
    {
        public int LogId { get; set; }

        /// <summary>
        /// 日志标题
        /// </summary>
        public string LogTitle { get; set; }

        /// <summary>
        /// 日志描述
        /// </summary>
        public string LogDescription { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public byte LogType { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public byte LogLevel { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 创建Ip
        /// </summary>
        public string CreatorIp { get; set; }
    }
}
