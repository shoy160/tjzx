using System.Collections.Generic;
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
                            new Navigation{Id = 1,Name = "关于我们",Sort = 1,Link = "/About",Class = "",Target = "_blank"},
                            new Navigation{Id = 2,Name = "健康资讯",Sort = 2,Link = "/News",Class = "",Target = "_blank"},
                            new Navigation{Id = 3,Name = "体检套餐",Sort = 3,Link = "/Medical",Class = "hot",Target = "_blank"},
                            new Navigation{Id = 4,Name = "体检预约",Sort = 4,Link = "/Reservation",Class = "hot",Target = "_blank"},
                            new Navigation{Id = 5,Name = "健康管理",Sort = 5,Link = "/Health",Class = "hot",Target = "_blank"},
                            new Navigation{Id = 6,Name = "中心概况",Sort = 6,Link = "/Overview",Class = "",Target = "_blank"},
                            new Navigation{Id = 7,Name = "咨询交流",Sort = 7,Link = "/Exchanges",Class = "",Target = "_blank"},
                            new Navigation{Id = 8,Name = "联系我们",Sort = 8,Link = "/Contact",Class = "",Target = "_blank"}
                        },
                    Sliders = new List<Slider>
                        {
                            new Slider{Id = 1,ImageUrl = "http://ued.tjzx.com/img/nopic01.gif",Link = "http://www.baidu.com",Sort = 4,Title = "百度"},
                            new Slider{Id = 2,ImageUrl = "http://ued.tjzx.com/img/nopic02.gif",Link = "http://www.baidu.com",Sort = 1,Title = "百度"},
                            new Slider{Id = 3,ImageUrl = "http://ued.tjzx.com/img/nopic03.gif",Link = "http://www.baidu.com",Sort = 3,Title = "百度"},
                            new Slider{Id = 4,ImageUrl = "http://ued.tjzx.com/img/nopic04.gif",Link = "http://www.baidu.com",Sort = 2,Title = "百度"}
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
                            new MenuItem{MenuId = 1,Name = "内容管理",Class = "icon-04",Depth = 0,Sort = 1},
                            new MenuItem{MenuId = 2,Name = "健康管理",Class = "icon-05",Depth = 0,Sort = 2},
                            new MenuItem{MenuId = 3,Name = "系统管理",Class = "icon-01",Depth = 0,Sort = 3},
                            new MenuItem{MenuId = 101, ParentId = 1,Name = "健康资讯",Link = "/m/news/index",Class = "icon-01",Depth = 1,Role = ManagerRole.News.GetValue(),Sort = 1},
                            new MenuItem{MenuId = 102, ParentId = 1,Name = "套餐分类",Link = "/m/category/index",Class = "icon-02",Depth = 1,Role = ManagerRole.Package.GetValue(),Sort = 2},
                            new MenuItem{MenuId = 103, ParentId = 1,Name = "体检套餐",Link = "/m/package/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Package.GetValue(),Sort = 3},
                            new MenuItem{MenuId = 103, ParentId = 1,Name = "流程及事项",Link = "/m/process/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Package.GetValue(),Sort = 4},
                            new MenuItem{MenuId = 103, ParentId = 1,Name = "预约列表",Link = "/m/reservation/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Reservation.GetValue(),Sort = 5},
                            new MenuItem{MenuId = 103, ParentId = 1,Name = "咨询交流",Link = "/m/consulting/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Consulting.GetValue(),Sort = 6},
                            new MenuItem{MenuId = 103, ParentId = 1,Name = "图片专栏",Link = "/m/album/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Overview.GetValue(),Sort = 7},
                            new MenuItem{MenuId = 201, ParentId = 2,Name = "会员管理",Link = "/m/member/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Health.GetValue(),Sort = 1},
                            new MenuItem{MenuId = 201, ParentId = 2,Name = "健康管理",Link = "/m/health/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Health.GetValue(),Sort = 2},
                            new MenuItem{MenuId = 202, ParentId = 2,Name = "健康评估",Link = "/m/assess/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Health.GetValue(),Sort = 3},
                            new MenuItem{MenuId = 301, ParentId = 3,Name = "用户管理",Link = "/m/user/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Users.GetValue(),Sort = 1},
                            new MenuItem{MenuId = 302, ParentId = 3,Name = "报告管理",Link = "/m/report/index",Class = "icon-03",Depth = 1,Role = ManagerRole.Report.GetValue(),Sort = 2}
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
                            Directories = new[] {"健康资讯", "中心公告"},
                            ImageExts = ".jpg,.jpeg,.gif,.png",
                            ImageSizeLimit = 500,
                            AttachExts = ".rar,.zip,.doc,.docx,.txt,.pdf,.swf,.avi,.rm,.rmvb,.mp4",
                            AttachSizeLimit = 30*1024
                        }
                };
            ConfigUtils<TjzxConfig>.Instance().Set(config);
            Assert.IsNotNull(ConfigUtils<TjzxConfig>.Instance().Get());
        }
    }
}
