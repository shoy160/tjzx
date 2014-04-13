using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    public enum UserType
    {
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")] Manager = 0,

        /// <summary>
        /// 会员用户
        /// </summary>
        [Description("会员用户")] Member = 1
    }
}
