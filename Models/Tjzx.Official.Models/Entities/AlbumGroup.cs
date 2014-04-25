using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 相册分组
    /// </summary>
    [Table("AlbumGroup")]
    public class AlbumGroup:EntityBase
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [MaxLength(200)]
        public string GroupName { get; set; }

        [Required]
        public byte State { get; set; }

        public int Sort { get; set; }
    }
}
