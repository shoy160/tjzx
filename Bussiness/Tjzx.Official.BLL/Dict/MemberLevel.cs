using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    public enum MemberLevel
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")] Normal = 0,

        /// <summary>
        /// Vip用户
        /// </summary>
        [Description("VIP用户")] Vip = 1
    }
}
