using System.Linq;
using Tjzx.BLL.Config;
using Tjzx.Official.BLL.Config;
using Shoy.Utility;
using System.Text;

namespace Tjzx.Official.BLL.Business
{
    public class IndexConfigBusi
    {
        private  readonly ConfigUtils<IndexConfig> _utils;

        public IndexConfigBusi()
        {
            _utils = ConfigUtils<IndexConfig>.Instance();
        }

        public ResultInfo UpdateNavigation(Navigation navigation)
        {
            if (navigation.Id <= 0)
                return new ResultInfo(0, "未找到相应的菜单项！");
            var config = _utils.Get();
            var nav = config.Navigations.FirstOrDefault(t => t.Id == navigation.Id);
            if (nav == null)
                return new ResultInfo(0, "未找到相应的菜单项！");
            navigation.Icon = Utils.UrlDecode(navigation.Icon, Encoding.UTF8);
            var index = config.Navigations.IndexOf(nav);
            config.Navigations[index] = navigation;
            _utils.Set(config);
            return new ResultInfo(1);
        }

        public ResultInfo UpdateSlider(Slider slider)
        {
            if (slider.Id <= 0)
                return new ResultInfo(0, "未找到相应的跑马灯！");
            var config = _utils.Get();
            var item = config.Sliders.FirstOrDefault(t => t.Id == slider.Id);
            if (item == null)
                return new ResultInfo(0, "未找到相应的跑马灯！");
            var index = config.Sliders.IndexOf(item);
            config.Sliders[index] = slider;
            _utils.Set(config);
            return new ResultInfo(1);
        }

        public ResultInfo UpdateCategory(Category category)
        {
            if (category.CategoryId <= 0)
                return new ResultInfo(0, "未找到相应的分类！");
            var config = _utils.Get();
            var item = config.Categories.FirstOrDefault(t => t.CategoryId == category.CategoryId);
            if (item == null)
                return new ResultInfo(0, "未找到相应的分类！");
            var index = config.Categories.IndexOf(item);
            config.Categories[index] = category;
            _utils.Set(config);
            return new ResultInfo(1);
        }

        public ResultInfo UpdateFriendsLink(WordLink wordLink)
        {
            if (wordLink.Id <= 0)
                return new ResultInfo(0, "未找到相应的友情链接！");
            var config = _utils.Get();
            var item = config.FriendsLink.FirstOrDefault(t => t.Id == wordLink.Id);
            if (item == null)
                return new ResultInfo(0, "未找到相应的分类！");
            var index = config.FriendsLink.IndexOf(item);
            config.FriendsLink[index] = wordLink;
            _utils.Set(config);
            return new ResultInfo(1);
        }
    }
}
