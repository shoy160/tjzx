using System;
using System.Linq;
using System.Text;
using Shoy.Utility;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    public class NewsBusi:BusiBase<NewsInfo>
    {
        /// <summary>
        /// 获取单个资讯的ResultInfo
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public override ResultInfo Item(int newsId)
        {
            var info = GetItem(newsId);
            if (info == null)
                return new ResultInfo(0, "未找到相关资讯！");
            var user = User.GetUser();
            if (!user.HaseRole(ManagerRole.News) && info.State != StateType.Display.GetValue())
                return new ResultInfo(0, "资讯尚未发布！");
            return new ResultInfo(1, "", new
                {
                    newsId = info.NewsId,
                    title = info.Title,
                    type = info.Type,
                    author = info.Author,
                    comefrom = info.Comefrom,
                    content = info.Content,
                    state = info.State
                });
        }


        /// <summary>
        /// 获取非自定义类型资讯,如体检流程、注意事项
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ResultInfo GetNonCustomItem(byte type)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Newses.FirstOrDefault(t => t.Type == type);
                if (item == null)
                {
                    return new ResultInfo(1, "", new {content = ""});
                }
                return new ResultInfo(1, "", new {content = item.Content});
            }
        }

        /// <summary>
        /// 更新非自定义类型资讯,如体检流程、注意事项
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public ResultInfo UpdateItem(byte type, string content)
        {
            using (var db = new EFDbContext())
            {
                var info = new NewsInfo
                    {
                        Title = ((NewsType) type).GetText(),
                        State = (byte) StateType.Display,
                        Type = type,
                        Content = content
                    };
                var item = db.Newses.FirstOrDefault(t => t.Type == type);
                if (item == null)
                {
                    return Insert(info);
                }
                info.NewsId = item.NewsId;
                return Update(info);
            }
        }

        /// <summary>
        /// 更新浏览量
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public ResultInfo UpdateViews(int newsId)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Newses.FirstOrDefault(t => t.NewsId == newsId);
                if (item == null) return new ResultInfo(0, "资讯不存在！");
                item.Views += 1;
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        /// <summary>
        /// 获取单个资讯
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public override NewsInfo GetItem(int newsId)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Newses.FirstOrDefault(t => t.NewsId == newsId);
                if (item == null) return null;
                return new NewsInfo
                    {
                        NewsId = item.NewsId,
                        Title = item.Title,
                        Author = item.Author,
                        Comefrom = item.Comefrom,
                        Type = item.Type,
                        State = item.State,
                        Content = item.Content,
                        Views = item.Views,
                        CreateOn = item.CreateOn
                    };
            }
        }

        /// <summary>
        /// 发布健康资讯
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override ResultInfo Insert(NewsInfo info)
        {
            var content = Utils.UrlDecode(info.Content, Encoding.UTF8);
            var user = User.GetUser();
            if (user == null || user.Type != UserType.Manager.GetValue())
                return new ResultInfo(0, "用户未登录！");
            using (var db = new EFDbContext())
            {
                var item = new News
                    {
                        Title = info.Title,
                        Type = info.Type,
                        Content = content,
                        CreateOn = DateTime.Now,
                        State = info.State,
                        CreatorId = user.UserId,
                        Creator = user.UserName,
                        Author = info.Author,
                        Comefrom = info.Comefrom
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.Newses.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    var msg = valid.ValidationErrors.FirstOrDefault();
                    if (msg != null)
                        return new ResultInfo(0, msg.ErrorMessage);
                    return new ResultInfo(0, "数据异常，请重试！");
                }
            }
            return new ResultInfo(1);
        }

        /// <summary>
        /// 获取健康资讯列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override ResultInfo GetList(SearchInfo info)
        {
            using (var db = new EFDbContext())
            {
                var count =
                    db.Newses.Count(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) ||
                         (t.Title.Contains(info.Keyword))) &&
                        (info.Type == Const.Ignore
                             ? (t.Type <= NewsTypeManager.CustomNewsTypeLimit)
                             : t.Type == info.Type) &&
                        (info.State == Const.Ignore ? t.State != (byte) StateType.Delete : t.State == info.State));
                var list =
                    db.Newses.Where(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) ||
                         (t.Title.Contains(info.Keyword))) &&
                        (info.Type == Const.Ignore
                             ? (t.Type <= NewsTypeManager.CustomNewsTypeLimit)
                             : t.Type == info.Type) &&
                        (info.State == Const.Ignore ? t.State != (byte) StateType.Delete : t.State == info.State))
                      .OrderByDescending(t => t.NewsId)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .Select(t => new
                          {
                              id = t.NewsId,
                              title = t.Title,
                              creator = t.Creator,
                              createon = t.CreateOn,
                              type = t.Type,
                              state = t.State,
                              recommend = t.IsRecommend
                          }).ToList()
                      .Select(t => new
                          {
                              t.id,
                              t.title,
                              t.creator,
                              createon = Const.FormatDate(t.createon),
                              t.type,
                              typeCN = ((int) t.type).GetEnumCssText<NewsType>(),
                              t.state,
                              stateCN =
                                       ((StateType) t.state).GetCssText(),
                              t.recommend
                          });
                return new ResultInfo(1, "", new {count, list});
            }
        }

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <param name="page">页码，从0开始</param>
        /// <param name="size">每页显示数量</param>
        /// <returns></returns>
        public ResultInfo GetDynamicNews(int page,int size)
        {
            using (var db = new EFDbContext())
            {
                var count =
                    db.Newses.Count(
                        t => t.Type == (byte) NewsType.Dynamic &&
                             t.State == (byte) StateType.Display);
                var list =
                    db.Newses.Where(
                        t => t.Type == (byte) NewsType.Dynamic &&
                             t.State == (byte) StateType.Display)
                      .OrderByDescending(t => t.NewsId)
                      .Skip(page*size)
                      .Take(size)
                      .Select(t => new
                          {
                              id = t.NewsId,
                              title = t.Title,
                              author = t.Author,
                              comefrom = t.Comefrom,
                              createon = t.CreateOn,
                              content = t.Content
                          }).ToList()
                      .Select(t => new
                          {
                              t.id,
                              t.title,
                              author = (string.IsNullOrEmpty(t.author) ? "未知" : t.author),
                              comefrom = (string.IsNullOrEmpty(t.comefrom) ? "未知" : t.comefrom),
                              time = Const.FormatDate(t.createon),
                              content = Utils.ClearHtml(t.content).Sub(300, "...")
                          });
                return new ResultInfo(1, "", new {count, list});
            }
        }
        

        /// <summary>
        /// 更新健康资讯
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override ResultInfo Update(NewsInfo info)
        {
            if (info == null || info.NewsId <= 0)
                return new ResultInfo(0, "未找到相应的资讯！");
            using (var db = new EFDbContext())
            {
                var item = db.Newses.FirstOrDefault(t => t.NewsId == info.NewsId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的资讯！");
                item.Title = info.Title;
                var content = Utils.UrlDecode(info.Content, Encoding.UTF8);
                item.Content = content;
                item.Type = info.Type;
                item.State = info.State;
                item.Author = info.Author;
                item.Comefrom = info.Comefrom;
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.SaveChanges();
                    return new ResultInfo(1);
                }
                var msg = valid.ValidationErrors.FirstOrDefault();
                if (msg != null)
                    return new ResultInfo(0, msg.ErrorMessage);
                return new ResultInfo(0, "数据异常，请重试！");
            }
        }

        /// <summary>
        /// 更新健康资讯状态
        /// </summary>
        /// <param name="ids">健康资讯ID</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public override ResultInfo UpdateState(int[] ids, StateType state)
        {
            if (ids.Length <= 0)
                return new ResultInfo(0, "未找到相应的资讯！");
            using (var db = new EFDbContext())
            {
                var list = db.Newses.Where(t => ids.Contains(t.NewsId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的资讯！");
                foreach (var item in list)
                {
                    item.State = (byte) state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="isRecommend"></param>
        /// <returns></returns>
        public ResultInfo SetRecommend(int[] ids, bool isRecommend)
        {
            if (ids.Length <= 0)
                return new ResultInfo(0, "未找到相应的资讯！");
            using (var db = new EFDbContext())
            {
                var list = db.Newses.Where(t => ids.Contains(t.NewsId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的资讯！");
                foreach (var item in list)
                {
                    item.IsRecommend = isRecommend;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public ResultInfo SetRecommend(int id, bool isRecommend)
        {
            return SetRecommend(new[] {id}, isRecommend);
        }
    }
}