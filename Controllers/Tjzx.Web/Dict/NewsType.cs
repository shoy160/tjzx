using System.ComponentModel;

namespace Tjzx.Web.Dict
{
    public enum NewsType
    {
        /// <summary>
        /// 新闻动态
        /// </summary>
        [Description("新闻资讯")] Dynamic = 0,

        /// <summary>
        /// 中心公告
        /// </summary>
        [Description("中心公告")] Announcement = 1
    }
}
