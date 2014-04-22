using System;
using System.Linq;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.BLL.Business
{
    /// <summary>
    /// 会员业务操作类
    /// </summary>
    public class MemberBusi:BusiBase<MemberInfo>
    {
        public override ResultInfo Insert(MemberInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new Member
                    {
                        IdNumber = info.IdNumber,
                        UserName = info.UserName,
                        PassWord = info.UserPwd.Md5().ToLower(),
                        RealName = info.RealName,
                        Mobile = info.Mobile,
                        UserLevel = info.Level,
                        CreateOn = DateTime.Now
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.Members.Add(item);
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
                var count = db.Members.Count(
                    t =>
                    (string.IsNullOrEmpty(info.Keyword) || t.UserName.Contains(info.Keyword) ||
                     t.RealName.Contains(info.Keyword)));
                var list =
                    db.Members.Where(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) || t.UserName.Contains(info.Keyword) ||
                         t.RealName.Contains(info.Keyword)))
                      .OrderByDescending(t => t.MemberId)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.MemberId,
                              userName = t.UserName,
                              realName = t.RealName,
                              mobile = t.Mobile,
                              level = t.UserLevel,
                              levelDesc = ((MemberLevel) t.UserLevel).GetText()
                          }).ToList();
                return new ResultInfo(1, "", new { count, list });
            }
        }

        public override ResultInfo Update(MemberInfo info)
        {
            if (info == null || info.MemberId <= 0)
                return new ResultInfo(0, "未找到相应的会员信息！");
            using (var db = new EFDbContext())
            {
                var item = db.Members.FirstOrDefault(t => t.MemberId == info.MemberId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的会员信息！");
                item.RealName = info.RealName;
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

        public override ResultInfo UpdateState(int[] ids, Dict.StateType state)
        {
            return new ResultInfo(0);
        }

        public override MemberInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Members.FirstOrDefault(t => t.MemberId == id);
                if (item == null) return null;
                return new MemberInfo
                    {
                        MemberId = item.MemberId,
                        RealName = item.RealName,
                        UserName = item.UserName,
                        Mobile = item.Mobile,
                        Level = item.UserLevel,
                        CreateOn = item.CreateOn
                    };
            }
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关会员信息！");
            return new ResultInfo(1, "", new
                {
                    memberId = info.MemberId,
                    userName = info.UserName,
                    realName = info.RealName,
                    mobile = info.Mobile,
                    createOn = Const.FormatDate(info.CreateOn),
                    level = info.Level,
                    levelDesc = ((MemberLevel) info.Level).GetText()
                });
        }
    }
}
