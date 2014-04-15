using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;

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


        /// <summary>
        /// 体检流程
        /// </summary>
        [Description("体检流程")] MedicalProcess = 101,

        /// <summary>
        /// 注意事项
        /// </summary>
        [Description("注意事项")] Attention = 102
    }

    public static class NewsTypeManager
    {
        public static List<NewsType> GetCustomNewsType()
        {
            return Enum.GetValues(typeof (NewsType)).Cast<NewsType>().Where(t => (int) t < 100).ToList();
        }

        public const byte CustomNewsTypeLimit = 100;

        public static bool IsCustomNewsType(byte type)
        {
            return type <= CustomNewsTypeLimit;
        }
    }
}
