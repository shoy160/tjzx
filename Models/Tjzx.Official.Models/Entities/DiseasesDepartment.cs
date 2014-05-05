using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 疾病科室
    /// </summary>
    [Table("DiseasesDepartment")]
    public class DiseasesDepartment:EntityBase
    {
        [Key]
        public int DiseasesDepartmentId { get; set; }

        /// <summary>
        /// 疾病科室名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string DiseasesDepartmentName { get; set; }

        public virtual List<Diseases> Diseaseses { get; set; }

        public int? Sort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public byte State { get; set; }
    }
}
