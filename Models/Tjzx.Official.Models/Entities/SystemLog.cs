using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 系统日志类
    /// </summary>
    [Table("SystemLog")]
    public class SystemLog : EntityBase
    {
        [Key]
        public int LogId { get; set; }

        /// <summary>
        /// 日志标题
        /// </summary>
        [Required]
        [MaxLength(300)]
        public string LogTitle { get; set; }

        /// <summary>
        /// 日志描述
        /// </summary>
        [Required]
        [MaxLength(600)]
        public string LogDescription { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Required]
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
        [Required]
        [MaxLength(150)]
        public string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 创建Ip
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string CreatorIp { get; set; }
    }
}
