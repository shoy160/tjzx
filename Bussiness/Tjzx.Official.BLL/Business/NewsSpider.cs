using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shoy.Utility;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.BLL.Business
{
    /// <summary>
    /// 资讯采集类
    /// </summary>
    public class NewsSpider
    {
        public static SpiderConfig GetConfig()
        {
            return new SpiderConfig
                {
                    Url = "http://www.jiankang.cn/info/list3_0_1.html",
                    Count = 10,
                    ListReg =
                        "<div[^>]*class=\"list\"[^>]*>([\\w\\W]*)</div>",
                    ItemReg = "<a[^>]*href=\"([^\"]+)\"[^>]*>([^<]+)</a><span>([^<]+)</span>",
                    TitleReg = "<div[^>]*class=\"zx109\"[^>]*>([^<]+)</div>",
                    ContentReg = "<div[^>]*class=\"my110\"[^>]*>([\\w\\W]+)</div>",
                    AuthorReg = "",
                    DateReg = ""
                };
        }

        public static int GetHtml()
        {
            var urls = GetListUrl();
            //return html.Aggregate("", (c, t) => c + (t + "\r\n"));
            var config = GetConfig();
            var busi = new NewsBusi();
            int count = 0;
            foreach (var url in urls)
            {
                using (var http = new HttpHelper(url))
                {
                    var item = new NewsInfo();
                    var html = http.GetHtml();
                    item.Title = GetRegexValue(config.TitleReg, html);
                    item.Comefrom = config.Comefrom;
                    item.Author = GetRegexValue(config.AuthorReg, html);
                    item.CreateOn = DateTime.Now;
                    item.Type = config.Type;
                    item.Content = GetRegexValue(config.ContentReg, html);
                    if (busi.Insert(item).state == 1) count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 获取列表链接
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetListUrl()
        {
            var config = GetConfig();
            var list = new List<string>();
            using (var http = new HttpHelper(config.Url))
            {
                var html = http.GetHtml();
                html = GetRegexValue(config.ListReg, html);
                var reg = new Regex(config.ItemReg);
                var uri = new Uri(config.Url);
                foreach (Match match in reg.Matches(html))
                {
                    var u = new Uri(uri, match.Groups[1].Value);
                    list.Add(u.ToString());
                    if (list.Count >= config.Count)
                        break;
                }
            }
            return list;
        }

        private static string GetRegexValue(string regex, string input)
        {
            var reg = new Regex(regex, RegexOptions.IgnoreCase);
            return reg.Match(input).Groups[1].Value;
        }
    }



    public class SpiderConfig
    {
        public string Url { get; set; }
        public int Count { get; set; }

        public string ListReg { get; set; }

        public string ItemReg { get; set; }

        public string TitleReg { get; set; }

        public string DateReg { get; set; }

        public string AuthorReg { get; set; }

        public string ContentReg { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string Comefrom { get; set; }

        public byte Type { get; set; }
    }
}
