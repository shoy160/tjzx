using System;

namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 相册业务类
    /// </summary>
    public class AlbumInfo:InfoBase
    {
        public int AlbumId { get; set; }

        public int GroupId { get; set; }

        public string Group { get; set; }

        public string Picture { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte State { get; set; }

        public DateTime CreateOn { get; set; }

        public string Creator { get; set; }
    }
}
