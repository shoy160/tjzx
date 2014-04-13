using System;
using System.ComponentModel;
using System.Linq;
using Shoy.Utility.Extend;

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

    public static class StateTypeMgr
    {
        public static string UserStateText(this StateType type)
        {
            switch (type)
            {
                case StateType.Hidden:
                    return "已停用";
                case StateType.Display:
                    return "已启用";
                case StateType.Delete:
                    return "已删除";
                default:
                    return "";
            }
        }

        public static string ConsultingStateText(this StateType type)
        {
            switch (type)
            {
                case StateType.Hidden:
                    return "未处理";
                case StateType.Display:
                    return "已处理";
                case StateType.Delete:
                    return "已删除";
                default:
                    return "";
            }
        }

        private static readonly string[] Colors = new[] {"Gray", "Green", "Red"};

        private static string GetColor(StateType type,string[] colors = null)
        {
            var list = Enum.GetValues(typeof(StateType)).Cast<StateType>().ToList();
            colors = colors ?? Colors;
            var index = list.IndexOf(type);
            if (index > colors.Length - 1) index = colors.Length - 1;
            var color = colors[index];
            return color;
        }

        public static string UserStateCssText(this StateType type, string[] colors = null)
        {
            var color = GetColor(type, colors);
            return string.Format("<span style=\"color:{0}\">{1}</span>", color, type.UserStateText());
        }

        public static string ConsultingStateCssText(this StateType type, string[] colors = null)
        {
            var color = GetColor(type, colors);
            return string.Format("<span style=\"color:{0}\">{1}</span>", color, type.ConsultingStateText());
        }

        public static string GetCssText(this StateType type)
        {
            return type.GetEnumCssText(Colors);
        }
    }
}
