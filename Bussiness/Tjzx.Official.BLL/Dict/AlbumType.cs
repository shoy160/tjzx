using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    public enum AlbumType
    {
        /// <summary>
        /// 已删除
        /// </summary>
        [Description("已删除")] Delete = -1,

        /// <summary>
        /// 普通相册
        /// </summary>
        [Description("普通相册")] Normal = 0,

        /// <summary>
        /// 首页展示
        /// </summary>
        [Description("首页展示")] ShowIndex = 1
    }
}
