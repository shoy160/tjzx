﻿namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 新闻资讯业务类
    /// </summary>
    public class NewsInfo
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public byte Type { get; set; }
        public byte State { get; set; }
        public string Author { get; set; }
        public string Comefrom { get; set; }
        public string Content { get; set; }
    }
}
