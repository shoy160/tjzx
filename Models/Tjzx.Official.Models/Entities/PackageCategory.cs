using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 套餐分类
    /// </summary>
    [Table("PackageCategory")]
    public class PackageCategory:EntityBase
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public int Sort { get; set; }

        public byte State { get; set; }

        public DateTime CreateOn { get; set; }

        public virtual List<MedicalPackage> MedicalPackages { get; set; }
    }
}
