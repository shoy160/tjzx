using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
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
        [Description("中心公告")] Announcement = 1,

        /// <summary>
        /// 健康知识
        /// </summary>
        [Description("健康知识")] HealthKnowledge = 2,
    }
}
