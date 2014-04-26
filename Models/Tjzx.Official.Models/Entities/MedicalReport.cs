using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 体检报告
    /// </summary>
    [Table("Report")]
    public class MedicalReport : EntityBase
    {
        [Key]
        public int ReportId { get; set; }

        /// <summary>
        /// 体检号
        /// </summary>
        public string MedicalNumber { get; set; }

        /// <summary>
        /// 体检时间
        /// </summary>
        public DateTime MedicalDate { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        [Required]
        public int MemberId { get; set; }

        /// <summary>
        /// 报告内容
        /// </summary>
        [Required]
        public string ReportContent { get; set; }
    }
}
