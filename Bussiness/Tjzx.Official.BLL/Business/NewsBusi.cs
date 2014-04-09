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
    public class NewsBusi
    {
        /// <summary>
        /// 发布新闻资讯
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static ResultInfo Insert(NewsInfo info)
        {
            var content = Utils.UrlDecode(info.Content, Encoding.UTF8);
            var user = User.GetUser();
            using (var db = new EFDbContext())
            {
                var item = new News
                    {
                        Title = info.Title,
                        Type = info.Type,
                        Content = content,
                        CreateOn = DateTime.Now,
                        State = (byte) StateType.Hidden,
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
        /// 获取新闻资讯列表
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="state">状态</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页显示数</param>
        /// <returns></returns>
        public static ResultInfo GetList(byte type, byte state, int page, int size)
        {
            using (var db = new EFDbContext())
            {
                var list =
                    db.Newses.Where(
                        t => (type == Const.Ignore || t.Type == type) && (state == Const.Ignore || t.State == state))
                      .OrderByDescending(t => t.NewsId)
                      .Skip(page*size)
                      .Take(size)
                      .Select(t => new
                          {
                              id = t.NewsId,
                              title = t.Title,
                              creator = t.Creator,
                              createon = t.CreateOn,
                              type = t.Type,
                              state = t.State
                          }).ToList()
                      .Select(t => new
                          {
                              t.id,
                              t.title,
                              t.creator,
                              createon = Const.FormatDate(t.createon),
                              type = ((int) t.type).GetEnumText<NewsType>(),
                              state = ((int) t.state).GetEnumText<StateType>()
                          });
                var count =
                    db.Newses.Count(
                        t => (type == Const.Ignore || t.Type == type) && (state == Const.Ignore || t.State == state));
                return new ResultInfo(1, "", new {count, list});
            }
        }

        /// <summary>
        /// 更新新闻资讯
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static ResultInfo Update(NewsInfo info)
        {
            if (info == null || info.NewsId <= 0)
                return new ResultInfo(0, "未找到相应的资讯！");
            using (var db = new EFDbContext())
            {
                var item = db.Newses.FirstOrDefault(t => t.NewsId == info.NewsId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的资讯！");
                item.Title = info.Title;
                item.Type = info.Type;
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
        /// 更新新闻资讯状态
        /// </summary>
        /// <param name="newsId">新闻资讯ID</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public static ResultInfo UpdateState(int newsId, StateType state)
        {
            if (newsId <= 0)
                return new ResultInfo(0, "未找到相应的资讯！");
            using (var db = new EFDbContext())
            {
                var item = db.Newses.FirstOrDefault(t => t.NewsId == newsId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的资讯！");
                item.State = (byte) state;
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }
    }
}
