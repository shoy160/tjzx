namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 相册分组业务类
    /// </summary>
    public class AlbumGroupInfo:InfoBase
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public byte State { get; set; }
    }
}
