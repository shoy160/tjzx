﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shoy.Utility.Extend;
using Tjzx.BLL.Config;
using Tjzx.Official.BLL.Config;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.Models.Test
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void InitConfigTest()
        {
            var config = new IndexConfig
                {
                    Navigations = new List<Navigation>
                        {
                            new Navigation{Id = 2,Name = "健康快车",Sort = 4,Link = "/news",Class = "",Target = "",Icon = "&#xf018;"},
                            new Navigation{Id = 3,Name = "体检套餐",Sort = 2,Link = "/packages",Class = "hot",Target = "",Icon = "&#xf0fa;"},
                            new Navigation{Id = 4,Name = "体检服务",Sort = 3,Link = "/reservation",Class = "hot",Target = "",Icon = "&#xf0ac;"},
                            //new Navigation{Id = 5,Name = "健康管理",Sort = 5,Link = "/h",Class = "hot",Target = ""},
                            new Navigation{Id = 6,Name = "中心概况",Sort = 1,Link = "/overview",Class = "",Target = "",Icon = "&#xf030;"},
                            new Navigation{Id = 7,Name = "咨询交流",Sort = 5,Link = "/exchanges",Class = "",Target = "",Icon = "&#xf0f4;"},
                            new Navigation{Id = 8,Name = "联系我们",Sort = 6,Link = "/contact",Class = "",Target = "",Icon = "&#xf095;"},
                            new Navigation{Id = 101,Name = "中心介绍", ParentId = 6,Sort = 1,Link = ""},
                            new Navigation{Id = 102,Name = "中心文化", ParentId = 6,Sort = 2,Link = ""},
                            new Navigation{Id = 103,Name = "中心环境", ParentId = 6,Sort = 3,Link = ""},
                            new Navigation{Id = 104,Name = "分布图", ParentId = 6,Sort = 4,Link = ""},
                            new Navigation{Id = 105,Name = "团队介绍", ParentId = 6,Sort = 5,Link = ""},
                            new Navigation{Id = 106,Name = "中心动态", ParentId = 6,Sort = 6,Link = ""},
                            new Navigation{Id = 107,Name = "中心公告", ParentId = 6,Sort = 7,Link = ""},
                            new Navigation{Id = 201,Name = "体检预约", ParentId = 4,Sort = 1,Link = ""},
                            new Navigation{Id = 202,Name = "体检流程", ParentId = 4,Sort = 2,Link = ""},
                            new Navigation{Id = 203,Name = "体检须知", ParentId = 4,Sort = 3,Link = ""},
                            new Navigation{Id = 204,Name = "报告领取查询", ParentId = 4,Sort = 4,Link = ""},
                            new Navigation{Id = 301,Name = "健康资讯", ParentId = 2,Sort = 1,Link = ""},
                            new Navigation{Id = 302,Name = "健康知识", ParentId = 2,Sort = 2,Link = ""},
                            new Navigation{Id = 303,Name = "疾病查询", ParentId = 2,Sort = 3,Link = ""},
                            new Navigation{Id = 304,Name = "健康自测", ParentId = 2,Sort = 4,Link = ""},
                            new Navigation{Id = 401,Name = "我要咨询", ParentId = 7,Sort = 1,Link = ""},
                            new Navigation{Id = 402,Name = "咨询列表", ParentId = 7,Sort = 2,Link = ""}
                        },
                    Sliders = new List<Slider>
                        {
                            new Slider{Id = 1,ImageUrl = "http://ued.shoy.com/img/pic01.jpg",Link = "http://www.baidu.com",Sort = 4,Title = "百度"},
                            new Slider{Id = 2,ImageUrl = "http://ued.shoy.com/img/pic02.jpg",Link = "http://www.baidu.com",Sort = 1,Title = "百度"},
                            new Slider{Id = 3,ImageUrl = "http://ued.shoy.com/img/pic03.jpg",Link = "http://www.baidu.com",Sort = 3,Title = "百度"},
                            new Slider{Id = 4,ImageUrl = "http://ued.shoy.com/img/pic04.jpg",Link = "http://www.baidu.com",Sort = 2,Title = "百度"}
                        },
                    Categories = new List<Category>
                        {
                            new Category{CategoryId = 1,CategoryName = "青少年体检套餐",ImageUrl = "/",Sort = 1},
                            new Category{CategoryId = 2,CategoryName = "压力族体检套餐",ImageUrl = "/",Sort = 2},
                            new Category{CategoryId = 3,CategoryName = "贵宾族体检套餐",ImageUrl = "/",Sort = 3},
                            new Category{CategoryId = 4,CategoryName = "VIP体检套餐",ImageUrl = "/",Sort = 4}
                        },
                    FriendsLink = new List<WordLink>
                            {
                                new WordLink{Id = 1,Title = "四川省人民医院",Link = "http://www.samsph.com/",Sort = 2},
                                new WordLink{Id = 2,Title = "四川省卫生厅",Link = "http://www.scwst.gov.cn/",Sort = 1}
                            }
                };
            ConfigUtils<IndexConfig>.Instance().Set(config);
            Assert.IsNotNull(ConfigUtils<IndexConfig>.Instance().Get());
        }

        [TestMethod]
        public void MenuInitTest()
        {
            var menu = new MenuConfig
                {
                    Menus = new List<MenuItem>
                        {
                            new MenuItem{MenuId = 1,Name = "内容管理",Icon = "&#xf009;",Depth = 0,Sort = 1},
                            new MenuItem{MenuId = 2,Name = "健康管理",Icon = "&#xf0fd;",Depth = 0,Sort = 2},
                            new MenuItem{MenuId = 3,Name = "系统管理",Icon = "&#xf013;",Depth = 0,Sort = 3},
                            new MenuItem{MenuId = 101, ParentId = 1,Name = "健康资讯",Link = "/m/news/index",Icon = "&#xf03d;",Depth = 1,Role = ManagerRole.News.GetValue(),Sort = 1},
                            new MenuItem{MenuId = 102, ParentId = 1,Name = "套餐分类",Link = "/m/category/index",Icon = "&#xf0fe;",Depth = 1,Role = ManagerRole.Package.GetValue(),Sort = 2},
                            new MenuItem{MenuId = 103, ParentId = 1,Name = "体检套餐",Link = "/m/package/index",Icon = "&#xf0fa;",Depth = 1,Role = ManagerRole.Package.GetValue(),Sort = 3},
                            new MenuItem{MenuId = 104, ParentId = 1,Name = "流程及事项",Link = "/m/process/index",Icon = "&#xf0e8;",Depth = 1,Role = ManagerRole.Package.GetValue(),Sort = 4},
                            new MenuItem{MenuId = 105, ParentId = 1,Name = "预约列表",Link = "/m/reservation/index",Icon = "&#xf02d;",Depth = 1,Role = ManagerRole.Reservation.GetValue(),Sort = 5},
                            new MenuItem{MenuId = 106, ParentId = 1,Name = "咨询交流",Link = "/m/consulting/index",Icon = "&#xf0f4;",Depth = 1,Role = ManagerRole.Consulting.GetValue(),Sort = 6},
                            new MenuItem{MenuId = 107, ParentId = 1,Name = "中心环境",Link = "/m/album/index",Icon = "&#xf03e;",Depth = 1,Role = ManagerRole.Overview.GetValue(),Sort = 7},
                            new MenuItem{MenuId = 108, ParentId = 1,Name = "疾病百科",Link = "/m/diseases/index",Icon = "&#xf0b1;",Depth = 1,Role = ManagerRole.Diseases.GetValue(),Sort = 8},
                            new MenuItem{MenuId = 201, ParentId = 2,Name = "会员管理",Link = "/m/member/index",Icon = "&#xf007;",Depth = 1,Role = ManagerRole.Health.GetValue(),Sort = 1},
                            //new MenuItem{MenuId = 201, ParentId = 2,Name = "健康管理",Link = "/m/health/index",Icon = "icon-03",Depth = 1,Role = ManagerRole.Health.GetValue(),Sort = 2},
                            //new MenuItem{MenuId = 202, ParentId = 2,Name = "健康评估",Link = "/m/assess/index",Icon = "icon-03",Depth = 1,Role = ManagerRole.Health.GetValue(),Sort = 3},
                            new MenuItem{MenuId = 301, ParentId = 3,Name = "用户管理",Link = "/m/user/index",Icon = "&#xf0f0;",Depth = 1,Role = ManagerRole.Users.GetValue(),Sort = 1},
                            new MenuItem{MenuId = 302, ParentId = 3,Name = "报告管理",Link = "/m/report/index",Icon = "&#xf080;",Depth = 1,Role = ManagerRole.Report.GetValue(),Sort = 2},
                            new MenuItem{MenuId = 303, ParentId = 3,Name = "首页配置",Link = "/m/homeconfig/index",Icon = "&#xf0ad;",Depth = 1,Role = ManagerRole.HomeConfig.GetValue(),Sort = 3}
                        }
                };
            ConfigUtils<MenuConfig>.Instance().Set(menu);
            Assert.IsNotNull(ConfigUtils<MenuConfig>.Instance().Get());
        }

        [TestMethod]
        public void InitTjzxConfig()
        {
            var config = new TjzxConfig
                {
                    Uploader = new UploaderConfig
                        {
                            BasePath = "/upload/",
                            Directories = new[] {"健康资讯", "健康知识", "中心动态", "中心公告"},
                            ImageExts = ".jpg,.jpeg,.gif,.png",
                            ImageSizeLimit = 500,
                            AttachExts = ".rar,.zip,.doc,.docx,.txt,.pdf,.swf,.avi,.rm,.rmvb,.mp4",
                            AttachSizeLimit = 30*1024
                        },
                    Email = new EmailConfig
                        {
                            SenderEmail = "",
                            SenderPwd = "",
                            SenderName = "",
                            SmtpHost = "",
                            SmtpPort = 0,
                            UseSsl = false
                        }
                };
            ConfigUtils<TjzxConfig>.Instance().Set(config);
            Assert.IsNotNull(ConfigUtils<TjzxConfig>.Instance().Get());
        }
    }
}
