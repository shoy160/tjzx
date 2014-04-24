using System;

namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 会员业务类
    /// </summary>
    [Serializable]
    public class MemberInfo : InfoBase
    {
        public int MemberId { get; set; }
        public string IdNumber { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string RealName { get; set; }
        public string NickName { get; set; }
        public string Mobile { get; set; }
        public byte Level { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
