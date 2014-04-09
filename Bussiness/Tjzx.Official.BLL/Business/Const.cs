using System;

namespace Tjzx.Official.BLL.Business
{
    public class Const
    {
        /// <summary>
        /// 忽略状态
        /// </summary>
        public const int Ignore = 101;

        /// <summary>
        /// 时间格式化
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm");
        }
    }
}
