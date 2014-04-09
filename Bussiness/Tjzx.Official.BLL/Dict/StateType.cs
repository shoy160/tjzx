using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    /// <summary>
    /// 状态类型
    /// </summary>
    public enum StateType
    {
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")] Delete = 2,

        /// <summary>
        /// 隐藏
        /// </summary>
        [Description("隐藏")] Hidden = 0,

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")] Display = 1
    }
}
