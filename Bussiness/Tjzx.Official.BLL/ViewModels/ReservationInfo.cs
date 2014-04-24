using System;

namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 套餐预约业务类
    /// </summary>
    public class ReservationInfo : InfoBase
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public int PackageId { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public byte Type { get; set; }
        public byte State { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreateOn { get; set; }
        public string Remark { get; set; }
        public int MemberId { get; set; }
    }
}
