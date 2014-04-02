﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tjzx.Official.Controllers.ViewModels;

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
                            new Navigation{Id = 2,Name = "新闻资讯",Sort = 2,Link = "/News",Class = "",Target = "_blank"},
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
            IndexConfig.Set(config);
        }
    }
}