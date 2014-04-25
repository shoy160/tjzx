using System;

namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 套餐预约业务类
    /// </summary>
    public class ReservationInfo : InfoBase
    {
        /// <summary>
        /// 预约ID
        /// </summary>
        public int ReservationId { get; set; }

        /// <summary>
        /// 预约人
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// 意向套餐
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 预约类型
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 预约状态
        /// </summary>
        public byte State { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 会员ID，登录状态下
        /// </summary>
        public int MemberId { get; set; }
    }
}
