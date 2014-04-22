using System;
using System.Linq;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    public class ManagerBusi:BusiBase<UserInfo>
    {
        public override ResultInfo GetList(SearchInfo info)
        {
            using (var db = new EFDbContext())
            {
                var count =
                    db.Managers.Count(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) ||
                         (t.UserName.Contains(info.Keyword) || (t.RealName != null && t.RealName.Contains(info.Keyword)))) &&
                        (info.Role == Const.Ignore || (t.Role & info.Role) > 0) &&
                        (info.State == Const.Ignore ? t.State != (byte) StateType.Delete : t.State == info.State));
                var list =
                    db.Managers.Where(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) ||
                         (t.UserName.Contains(info.Keyword) || (t.RealName != null && t.RealName.Contains(info.Keyword)))) &&
                         (info.Role == Const.Ignore || (t.Role & info.Role) > 0) &&
                        (info.State == Const.Ignore ? t.State != (byte) StateType.Delete : t.State == info.State))
                      .OrderByDescending(t => t.ManagerId)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .Select(t => new
                          {
                              id = t.ManagerId,
                              account = t.UserName,
                              name = t.RealName,
                              createon = t.CreateOn,
                              roles = t.Role,
                              state = t.State
                          }).ToList()
                      .Select(t => new
                          {
                              t.id,
                              t.account,
                              t.name,
                              createon = Const.FormatDate(t.createon),
                              t.state,
                              roles = GetRolesText(t.roles),
                              stateCN = ((StateType) t.state).UserStateCssText()
                          });
                return new ResultInfo(1, "", new {count, list});
            }
        }

        public override ResultInfo Insert(UserInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new Manager
                    {
                        RealName = info.Name,
                        UserName = info.Account,
                        PassWord = info.Password.Md5().ToLower(),
                        State = info.State,
                        Role = info.Role,
                        CreateOn = DateTime.Now
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.Managers.Add(item);
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

        public override ResultInfo Update(UserInfo info)
        {
            if (info == null || info.UserId <= 0)
                return new ResultInfo(0, "未找到相应的人员！");
            using (var db = new EFDbContext())
            {
                var item = db.Managers.FirstOrDefault(t => t.ManagerId == info.UserId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的人员！");
                item.RealName = info.Name;
                item.UserName = info.Account;
                if (!string.IsNullOrEmpty(info.Password))
                    item.PassWord = info.Password.Md5().ToLower();
                item.State = info.State;
                item.Role = info.Role;
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
                return new ResultInfo(0, "未找到相应的用户！");
            using (var db = new EFDbContext())
            {
                var list = db.Managers.Where(t => ids.Contains(t.ManagerId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的用户！");
                foreach (var item in list)
                {
                    item.State = (byte)state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public override UserInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Managers.FirstOrDefault(t => t.ManagerId == id);
                if (item == null) return null;
                return new UserInfo
                    {
                        UserId = item.ManagerId,
                        Name = item.RealName,
                        Account = item.UserName,
                        State = item.State,
                        Roles = GetRoles(item.Role),
                        CreateOn = item.CreateOn
                    };
            }
        }

        private int[] GetRoles(int role)
        {
            if (role == ManagerRole.Admin.GetValue()) return new[] {role};
            return (from ManagerRole managerRole in Enum.GetValues(typeof (ManagerRole))
                    where managerRole != ManagerRole.Admin && (role & (int)managerRole) > 0
                    select managerRole.GetValue()).ToArray();
        }

        private string GetRolesText(int role)
        {
            if (role == ManagerRole.Admin.GetValue()) return ManagerRole.Admin.GetText();
            return (from ManagerRole managerRole in Enum.GetValues(typeof (ManagerRole))
                    where managerRole != ManagerRole.Admin && (role & (int) managerRole) > 0
                    select managerRole.GetText()).Aggregate("", (c, t) => c + t + ",").TrimEnd(',');
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关资讯！");
            return new ResultInfo(1, "", new
                {
                    userId = info.UserId,
                    name = info.Name,
                    account = info.Account,
                    roles = info.Roles,
                    state = info.State
                });
        }
    }
}
