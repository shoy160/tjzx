﻿namespace Tjzx.Official.BLL.Business
{
    /// <summary>
    /// 搜索 业务类
    /// </summary>
    public class SearchInfo
    {
        private byte _type = Const.Ignore;
        private byte _state = Const.Ignore;
        private int _page = 0;
        private int _size = 15;

        public string Keyword { get; set; }

        public byte Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public byte State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int Page
        {
            get { return _page; }
            set { _page = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
    }
}