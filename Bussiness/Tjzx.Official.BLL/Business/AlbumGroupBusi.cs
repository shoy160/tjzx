using System;
using System.Linq;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    public class AlbumGroupBusi:BusiBase<AlbumGroupInfo>
    {
        public override ResultInfo Insert(AlbumGroupInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new AlbumGroup
                    {
                        GroupName = info.GroupName,
                        State = info.State
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.AlbumGroups.Add(item);
                    db.SaveChanges();
                    return new ResultInfo(1);
                }
                var msg = valid.ValidationErrors.FirstOrDefault();
                if (msg != null)
                    return new ResultInfo(0, msg.ErrorMessage);
                return new ResultInfo(0, "数据异常，请重试！");
            }
        }

        public override ResultInfo GetList(SearchInfo info)
        {
            using (var db = new EFDbContext())
            {
                var count = db.AlbumGroups.Count(
                    t =>
                    (string.IsNullOrEmpty(info.Keyword) ||
                     t.GroupName.Contains(info.Keyword)) &&
                    (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.AlbumGroups.Where(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) || t.GroupName.Contains(info.Keyword)) &&
                        (info.State == Const.Ignore || t.State == info.State))
                      .OrderByDescending(t => t.GroupId)
                      .ThenBy(t => t.Sort)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.GroupId,
                              name = t.GroupName,
                              state = t.State,
                              stateCN = ((StateType) t.State).GetCssText()
                          }).ToList();
                return new ResultInfo(1, "", new {count, list});
            }
        }

        public override ResultInfo Update(AlbumGroupInfo info)
        {
            if (info == null || info.GroupId <= 0)
                return new ResultInfo(0, "未找到相应的相册分组！");
            using (var db = new EFDbContext())
            {
                var item = db.AlbumGroups.FirstOrDefault(t => t.GroupId == info.GroupId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的相册分组！");
                item.GroupName = info.GroupName;
                item.State = info.State;
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

        public override ResultInfo UpdateState(int[] ids, StateType state)
        {
            if (ids == null || ids.Length == 0)
                return new ResultInfo(0, "未找到相应的相册分组！");
            using (var db = new EFDbContext())
            {
                var list = db.AlbumGroups.Where(t => ids.Contains(t.GroupId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的相册分组！");
                foreach (var item in list)
                {
                    item.State = (byte)state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public override AlbumGroupInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.AlbumGroups.FirstOrDefault(t => t.GroupId == id);
                if (item == null) return null;
                return new AlbumGroupInfo
                    {
                        GroupId = item.GroupId,
                        GroupName = item.GroupName,
                        State = item.State
                    };
            }
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关相册分组！");
            return new ResultInfo(1, "", new
                {
                    groupId = info.GroupId,
                    name = info.GroupName,
                    state = info.State
                });
        }
    }
}
