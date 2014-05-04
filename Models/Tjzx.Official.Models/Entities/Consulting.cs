using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 咨询交流
    /// </summary>
    [Table("Consulting")]
    public class Consulting:EntityBase
    {
        [Key]
        public int ConsultingId { get; set; }

        /// <summary>
        /// 咨询主题
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// 咨询内容
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [MaxLength(100)]
        public string Contact { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [MaxLength(20)]
        public string Mobile { get; set; }

        public byte State { get; set; }

        /// <summary>
        /// 处理情况
        /// </summary>
        [MaxLength(600)]
        public string DeelSituation { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? DeelTime { get; set; }

        public DateTime CreateOn { get; set; }

        [MaxLength(30)]
        public string CreatorIp { get; set; }

        public int MemberId { get; set; }
    }
}
