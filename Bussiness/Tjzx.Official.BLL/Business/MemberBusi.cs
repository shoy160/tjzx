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
                //用户名重复检测
                if (!CheckUserName(info.UserName, 0, db))
                {
                    return new ResultInfo(0, "用户名不能重复！");
                }
                var item = new Member
                    {
                        IdNumber = info.IdNumber,
                        UserName = info.UserName,
                        PassWord = info.UserPwd.Md5().ToLower(),
                        RealName = info.RealName,
                        Mobile = info.Mobile,
                        UserLevel = info.Level,
                        State = (byte) StateType.Display,
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
                     t.RealName.Contains(info.Keyword))
                    && (info.Role == Const.Ignore || t.UserLevel == info.Role));
                var list =
                    db.Members.Where(
                        t =>
                        (string.IsNullOrEmpty(info.Keyword) || t.UserName.Contains(info.Keyword) ||
                         t.RealName.Contains(info.Keyword))
                        && (info.Role == Const.Ignore || t.UserLevel == info.Role))
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
                              levelDesc = ((MemberLevel) t.UserLevel).GetEnumCssText(new[] {"Black", "Green"}),
                              state = t.State,
                              stateCN = ((StateType) t.State).UserStateCssText(),
                              createon = Const.FormatDate(t.CreateOn)
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
                if (!CheckUserName(info.UserName, info.MemberId, db))
                {
                    return new ResultInfo(0, "用户名名不能重复！");
                }
                var item = db.Members.FirstOrDefault(t => t.MemberId == info.MemberId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的会员信息！");
                item.RealName = info.RealName;
                item.UserLevel = info.Level;
                item.UserName = info.UserName;
                if (!string.IsNullOrEmpty(info.UserPwd))
                {
                    item.PassWord = info.UserPwd.Md5().ToLower();
                }
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
                return new ResultInfo(0, "未找到相应的会员！");
            using (var db = new EFDbContext())
            {
                var list = db.Members.Where(t => ids.Contains(t.MemberId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的会员！");
                foreach (var item in list)
                {
                    item.State = (byte) state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
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
                        CreateOn = item.CreateOn,
                        Ticket = item.Ticket
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

        /// <summary>
        /// 检验用户名重复
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userId">会员ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool CheckUserName(string userName, int userId, EFDbContext db)
        {
            return db.Members.Count(t => t.UserName == userName && t.MemberId != userId) == 0;
        }

        public bool CheckUserName(string userName, int userId)
        {
            using (var db = new EFDbContext())
                return CheckUserName(userName, userId, db);
        }

        /// <summary>
        /// 检验身份证号码重复
        /// </summary>
        /// <param name="idNumber">身份证号码</param>
        /// <param name="userId">会员ID</param>
        /// <param name="db"></param>
        /// <returns>是否重复</returns>
        public bool CheckIdNumber(string idNumber, int userId,EFDbContext db)
        {
            return db.Members.Count(t => t.IdNumber == idNumber && t.MemberId != userId) == 0;
        }

        public bool CheckIdNumber(string idNumber, int userId)
        {
            using (var db = new EFDbContext())
                return CheckIdNumber(idNumber, userId, db);
        }
    }
}
