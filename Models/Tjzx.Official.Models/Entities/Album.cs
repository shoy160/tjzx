using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 中心环境相册
    /// </summary>
    [Table("Album")]
    public class Album : EntityBase
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual AlbumGroup Group { get; set; }

        [Required]
        [MaxLength(300)]
        public string Picture { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CreatorId { get; set; }

        public int Sort { get; set; }

        public byte State { get; set; }

        [Required]
        [MaxLength(30)]
        public string Creator { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }
    }
}
