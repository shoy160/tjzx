namespace Tjzx.Official.BLL.Business
{
    public class ResultInfo
    {
        public int state { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }

        public ResultInfo(int state, string msg = "", object data = null, string code = "")
        {
            this.state = state;
            this.msg = msg;
            this.code = code;
            this.data = data;
        }
    }
}
