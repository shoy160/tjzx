﻿using System;
using System.ComponentModel;

namespace Tjzx.Official.BLL.Dict
{
    [Flags]
    public enum ManagerRole
    {
        /// <summary>
        /// 无权限
        /// </summary>
        [Description("无权限")] None = 0,

        /// <summary>
        /// 健康资讯
        /// </summary>
        [Description("健康资讯")] News = 0x1,

        /// <summary>
        /// 体检套餐
        /// </summary>
        [Description("体检套餐")] Package = 0x2,

        /// <summary>
        /// 预约管理
        /// </summary>
        [Description("预约管理")] Reservation = 0x4,

        /// <summary>
        /// 咨询交流
        /// </summary>
        [Description("咨询交流")] Consulting = 0x8,

        /// <summary>
        /// 中心概况(图片专栏)
        /// </summary>
        [Description("中心环境")] Overview = 0x10,

        /// <summary>
        /// 健康管理
        /// </summary>
        [Description("健康管理")] Health = 0x20,

        /// <summary>
        /// 人员管理
        /// </summary>
        [Description("人员管理")] Users = 0x40,

        /// <summary>
        /// 报告管理
        /// </summary>
        [Description("报告管理")] Report = 0x80,

        /// <summary>
        /// 会员管理
        /// </summary>
        [Description("会员管理")] Member = 0x100,

        /// <summary>
        /// 疾病百科
        /// </summary>
        [Description("疾病百科")] Diseases= 0x200,

        /// <summary>
        /// 首页配置
        /// </summary>
        [Description("首页配置")] HomeConfig=0x400,

        /// <summary>
        /// 超级管理员
        /// </summary>
        [Description("超级管理员")] Admin = 0xFFFFFFF
    }
}
