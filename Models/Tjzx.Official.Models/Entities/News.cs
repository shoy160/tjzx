using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Tjzx.Official.Models.Entities
{
    /// <summary>
    /// 健康资讯类
    /// </summary>
    [Table("News")]
    public class News : EntityBase
    {
        [Key]
        public int NewsId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "请填写咨询标题！")]
        [MaxLength(300, ErrorMessage = "资讯标题不得超过300个字符")]
        [DisplayName("资讯标题")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "请填写咨询内容！")]
        [DisplayName("资讯内容")]
        public string Content { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [DisplayName("发布时间")]
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [MaxLength(150)]
        public string Comefrom { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [MaxLength(120)]
        public string Author { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public byte State { get; set; }

        public int CreatorId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Creator { get; set; }
    }
}
