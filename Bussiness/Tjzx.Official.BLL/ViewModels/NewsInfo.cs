using System;
namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 健康资讯业务类
    /// </summary>
    public class NewsInfo:InfoBase
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public byte Type { get; set; }
        public byte State { get; set; }
        public string Author { get; set; }
        public string Comefrom { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
