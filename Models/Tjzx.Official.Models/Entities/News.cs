using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 新闻类
    /// </summary>
    [Table("News")]
    public class News
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        public int CreatorId { get; set; }

        [MaxLength(120)]
        [Required]
        public string Creator { get; set; }

        /// <summary>
        /// 点击次数
        /// </summary>
        public int Clicks { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public byte State { get; set; }
    }
}
