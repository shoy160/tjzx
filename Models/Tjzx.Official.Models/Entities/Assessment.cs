using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 健康评估
    /// </summary>
    [Table("Assessment")]
    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }

        /// <summary>
        /// 体检号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string MedicalNum { get; set; }

        /// <summary>
        /// 风险评估
        /// </summary>
        [MaxLength(600)]
        public string RiskAssessment { get; set; }

        /// <summary>
        /// 异常指标
        /// </summary>
        [MaxLength(600)]
        public string AnomalyIndex { get; set; }

        /// <summary>
        /// 行为模式评估
        /// </summary>
        [MaxLength(600)]
        public string BehaviorPatterns { get; set; }

        /// <summary>
        /// 主要健康问题
        /// </summary>
        public string MainProblem { get; set; }


        public int CreatorId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Creator { get; set; }
        
        public DateTime CreateOn { get; set; }
    }
}
