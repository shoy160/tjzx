using System;

namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 咨询交流业务类
    /// </summary>
    public class ConsultingInfo:InfoBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Contact { get; set; }

        public string Mobile { get; set; }

        public byte State { get; set; }

        public string DeelSituation { get; set; }

        public DateTime DeelTime { get; set; }

        public DateTime CreateOn { get; set; }

        public int MemberId { get; set; }
    }
}
