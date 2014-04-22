using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 体检报告
    /// </summary>
    [Table("Report")]
    public class Report : EntityBase
    {
        [Key]
        public int ReportId { get; set; }

        /// <summary>
        /// 体检号
        /// </summary>
        public string MedicalNum { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 报告内容
        /// </summary>
        public string ReportContent { get; set; }
    }
}
