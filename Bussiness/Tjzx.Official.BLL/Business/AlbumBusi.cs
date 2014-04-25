using System;
using System.Linq;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    public class AlbumBusi:BusiBase<AlbumInfo>
    {
        public override ResultInfo Insert(AlbumInfo info)
        {
            var user = User.GetUser();
            if (user == null || user.Type != (byte) UserType.Manager)
                return new ResultInfo(-1, "操作需要登录！");
            using (var db = new EFDbContext())
            {
                var item = new Album
                    {
                        GroupId = info.GroupId,
                        State = info.State,
                        Picture = info.Picture,
                        Name = info.Name,
                        Description = info.Description,
                        CreateOn = DateTime.Now,
                        CreatorId = user.UserId,
                        Creator = user.UserName,
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.Albums.Add(item);
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

        public override ResultInfo GetList(SearchInfo info)
        {
            using (var db = new EFDbContext())
            {
                var count =
                    db.Albums.Count(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) ||
                         (t.Name.Contains(info.Keyword))) &&
                        (info.State == Const.Ignore ? t.State != (byte)StateType.Delete : t.State == info.State));
                var list =
                    db.Albums.Where(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) ||
                         (t.Name.Contains(info.Keyword))) &&
                        (info.State == Const.Ignore ? t.State != (byte) StateType.Delete : t.State == info.State))
                      .OrderByDescending(t => t.AlbumId)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .Select(t => new
                          {
                              id = t.AlbumId,
                              picture=t.Picture,
                              name = t.Name,
                              t.Description,
                              t.GroupId,
                              t.Group.GroupName,
                              creator = t.Creator,
                              createon = t.CreateOn,
                              state = t.State
                          }).ToList()
                      .Select(t => new
                          {
                              t.id,
                              t.picture,
                              t.name,
                              desc = t.Description,
                              groupId = t.GroupId,
                              groupName = t.GroupName,
                              t.creator,
                              createon = Const.FormatDate(t.createon),
                              t.state ,
                              stateCN = ((int) t.state).GetEnumCssText<StateType>()
                          });
                return new ResultInfo(1, "", new {count, list});
            }
        }

        public override ResultInfo Update(AlbumInfo info)
        {
            if (info == null || info.AlbumId <= 0)
                return new ResultInfo(0, "未找到相应的相册！");
            using (var db = new EFDbContext())
            {
                var item = db.Albums.FirstOrDefault(t => t.AlbumId == info.AlbumId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的相册！");
                item.Name = info.Name;
                item.Description = info.Description;
                item.State = info.State;
                item.Picture = info.Picture;
                item.GroupId = info.GroupId;
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
            if (ids.Length <= 0)
                return new ResultInfo(0, "未找到相应的相册！");
            using (var db = new EFDbContext())
            {
                var list = db.Albums.Where(t => ids.Contains(t.AlbumId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的相册！");
                foreach (var item in list)
                {
                    item.State = (byte)state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public override AlbumInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Albums.FirstOrDefault(t => t.AlbumId == id);
                if (item == null) return null;
                return new AlbumInfo
                    {
                        AlbumId = item.AlbumId,
                        Name = item.Name,
                        Description = item.Description,
                        Picture = item.Picture,
                        GroupId = item.GroupId,
                        Group = item.Group.GroupName,
                        State = item.State,
                        CreateOn = item.CreateOn
                    };
            }
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关相册！");
            var user = User.GetUser();
            if (!user.HaseRole(ManagerRole.Overview) && info.State != StateType.Display.GetValue())
                return new ResultInfo(0, "相册尚未发布！");
            return new ResultInfo(1, "", new
                {
                    albumId = info.AlbumId,
                    name = info.Name,
                    description = info.Description,
                    picture = info.Picture,
                    groupId = info.GroupId,
                    group = info.Group,
                    state = info.State
                });
        }
    }
}
