using System;

namespace Tjzx.Official.BLL
{
    public class Const
    {
        /// <summary>
        /// 忽略状态
        /// </summary>
        public const int Ignore = 101;

        public const string PackageImageDirectory = "MedicalPackages";

        public const string DefaultPackageName = "到院选择";

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
