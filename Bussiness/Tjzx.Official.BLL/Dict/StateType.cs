using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    /// <summary>
    /// 状态类型
    /// </summary>
    public enum StateType
    {
        /// <summary>
        /// 隐藏
        /// </summary>
        [Description("隐藏")] Hidden = 0,

        /// <summary>
        /// 显示
        /// </summary>
        [Description("显示")] Display = 1,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")] Delete = 2
    }
}
