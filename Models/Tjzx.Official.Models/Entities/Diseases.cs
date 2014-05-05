using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 疾病类
    /// </summary>
    [Table("Diseases")]
    public class Diseases : EntityBase
    {
        [Key]
        public int DiseasesId { get; set; }

        /// <summary>
        /// 疾病名称
        /// </summary>
        [Required]
        [MaxLength(60)]
        public string DiseasesName { get; set; }

        [Required]
        public int DiseasesDepartmentId { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [ForeignKey("DiseasesDepartmentId")]
        public virtual DiseasesDepartment DiseasesDepartment { get; set; }

        [Required]
        public string DiseasesDescription { get; set; }

        public int? Sort { get; set; }

        public byte State { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }

        public int CreatorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Creator { get; set; }
    }
}
