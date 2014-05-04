using System;

namespace Tjzx.Official.BLL.Business
{
    /// <summary>
    /// 搜索 业务类
    /// </summary>
    public class SearchInfo
    {
        private byte _type = Const.Ignore;
        private byte _state = Const.Ignore;
        private byte _deelState = Const.Ignore;
        private int _role = Const.Ignore;
        private int _categoryId = Const.Ignore;
        private int _size = 15;

        public SearchInfo()
        {
            Page = 0;
            EndTime = null;
            StartTime = null;
        }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public int Role
        {
            get { return _role; }
            set { _role = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public byte Type
        {
            get { return _type; }
            set { _type = value; }
        }


        /// <summary>
        /// 状态
        /// </summary>
        public byte State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 处理情况
        /// </summary>
        public byte DeelState
        {
            get { return _deelState; }
            set { _deelState = value; }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 当前页(0开始)
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }
    }
}
