using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    /// <summary>
    /// 预约状态
    /// </summary>
    public enum ReservationState
    {
        [Description("暂未处理")] None = 0,
        [Description("有效预约")] Effective = 1,
        [Description("无效预约")] Invalid = 2,
        [Description("取消预约")] Cancel = 3
    }
}
