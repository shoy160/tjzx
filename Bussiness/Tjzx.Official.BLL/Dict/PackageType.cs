using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    /// <summary>
    /// 套餐类型
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// 普通套餐
        /// </summary>
        [Description("普通套餐")] Normal = 0,

        /// <summary>
        /// 热门套餐
        /// </summary>
        [Description("热门套餐")] Hot = 1,

        /// <summary>
        /// 推荐套餐
        /// </summary>
        [Description("推荐套餐")] Recommend = 2
    }
}
