using System;
using System.ComponentModel.DataAnnotations;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 会员类
    /// </summary>
    public class Member:EntityBase
    {
        [Key]
        public int MemberId { get; set; }

        /// <summary>
        /// 身份证号码，全局唯一
        /// </summary>
        [Required]
        [MaxLength(18)]
        public string IdNumber { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string RealName { get; set; }

        /// <summary>
        /// 用户名，用于自定义登录名，开通时默认为身份证号码
        /// </summary>
        [Required]
        [MinLength(6)]
        [MaxLength(25)]
        public string UserName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(20)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(120)]
        public string PassWord { get; set; }

        /// <summary>
        /// 用户登录令牌
        /// </summary>
        [MaxLength(50)]
        public string Ticket { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后一次登录Ip
        /// </summary>
        [MaxLength(30)]
        public string LastLoginIp { get; set; }
        
        /// <summary>
        /// 用户等级：0，普通用户；1，健康管理用户
        /// </summary>
        public byte UserLevel { get; set; }

        public DateTime CreateOn { get; set; }
    }
}
