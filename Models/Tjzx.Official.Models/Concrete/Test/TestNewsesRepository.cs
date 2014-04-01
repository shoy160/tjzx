using System.Collections.Generic;
using System.ComponentModel;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;
using System;

namespace Tjzx.Official.Models.Concrete
{
    public class TestNewsesRepository:IRepository<News>
    {
        public IEnumerable<News> Values
        {
            get
            {
                return new BindingList<News>
                    {
                        new News
                            {
                                NewsId = 1,
                                Title = "新闻标题",
                                Content = "新闻内容",
                                CreateOn = DateTime.Now,
                                Type = 0,
                                State = 1
                            }
                    };
            }
        }
    }
}
