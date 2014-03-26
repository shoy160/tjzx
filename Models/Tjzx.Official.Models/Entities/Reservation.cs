using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 预约信息
    /// </summary>
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        /// <summary>
        /// 预约类型：0，个人体检；1：团队体检
        /// </summary>
        [Required]
        public byte Type { get; set; }

        [Required]
        public int PackageId { get; set; }

        [ForeignKey("PackageId")]
        public MedicalPackage Package { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 单位名称,团队预约时需要填写
        /// </summary>
        [MaxLength(120)]
        public string Company { get; set; }

        /// <summary>
        /// 单位地址，团队预约时填写
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [MaxLength(15)]
        [Required]
        public string Mobile { get; set; }

        [MaxLength(150)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(600)]
        public string Remark { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 预约者IP
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string CreatorIp { get; set; }

        /// <summary>
        /// 预约状态
        /// </summary>
        public byte State { get; set; }
    }
}
