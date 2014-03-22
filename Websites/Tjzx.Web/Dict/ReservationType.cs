using System.ComponentModel;

namespace Tjzx.Web.Dict
{
    /// <summary>
    /// 预约类型
    /// </summary>
    public enum ReservationType
    {
        /// <summary>
        /// 个人体检
        /// </summary>
        [Description("个人体检")] Personal = 0,

        /// <summary>
        /// 团队体检
        /// </summary>
        [Description("团队体检")] Team = 1
    }
}
