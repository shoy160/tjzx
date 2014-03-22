using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 体检套餐
    /// </summary>
    [Table("MedicalPackage")]
    public class MedicalPackage
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 套餐名称
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        /// <summary>
        /// 套餐类别
        /// </summary>
        [ForeignKey("CategoryId")]
        public virtual PackageCategory Category { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        [Required]
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 优惠价
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// 套餐类型：0，普通；1，热门；2，推荐
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 适合人群
        /// </summary>
        [MaxLength(350)]
        [Required]
        public string ForTheCrowd { get; set; }
        /// <summary>
        /// 套餐特点
        /// </summary>
        [MaxLength(300)]
        [Required]
        public string Feature { get; set; }
        /// <summary>
        /// 推荐项目
        /// </summary>
        [MaxLength(500)]
        [Required]
        public string Recommends { get; set; }
        /// <summary>
        /// 套餐详情
        /// </summary>
        [Required]
        public string Details { get; set; }
    }
}
