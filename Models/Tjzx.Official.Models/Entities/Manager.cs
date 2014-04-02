using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 后台管理员
    /// </summary>
    [Table("Manager")]
    public class Manager : EntityBase
    {
        [Key]
        public int ManagerId { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string PassWord { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(50)]
        public string RealName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(20)]
        public string Mobile { get; set; }
        
        /// <summary>
        /// 权限值
        /// </summary>
        public int Role { get; set; }

        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public byte State { get; set; }
    }
}
