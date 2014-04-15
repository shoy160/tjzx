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
    public class ConsultingBusi : BusiBase<ConsultingInfo>
    {
        public override ResultInfo Insert(ConsultingInfo info)
        {
            using (var db = new EFDbContext())
            {
                var content = Utils.UrlDecode(info.Contact, Encoding.UTF8);
                var item = new Consulting
                    {
                        Title = info.Title,
                        Content = content,
                        Contact = info.Contact,
                        Mobile = info.Mobile,
                        CreatorIp = Utils.GetRealIp(),
                        State = (byte) StateType.Hidden,
                        CreateOn = DateTime.Now
                    };
                var user = User.GetUser();
                if (user != null && user.Type == UserType.Member.GetValue())
                    item.MemberId = user.UserId;
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.Consultings.Add(item);
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
                var count = db.Consultings.Count(
                    t =>
                    (string.IsNullOrEmpty(info.Keyword) ||
                     t.Title.Contains(info.Keyword)) &&
                    (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.Consultings.Where(
                        t => (string.IsNullOrEmpty(info.Keyword) ||
                              t.Title.Contains(info.Keyword)) &&
                             (info.State == Const.Ignore || t.State == info.State))
                      .OrderByDescending(t => t.ConsultingId)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.ConsultingId,
                              title = t.Title,
                              content = t.Content,
                              contact = t.Contact,
                              mobile = t.Mobile,
                              createon = Const.FormatDate(t.CreateOn),
                              state = t.State,
                              stateCN = ((StateType) t.State).GetCssText()
                          }).ToList();
                return new ResultInfo(1, "", new {count, list});
            }
        }

        /// <summary>
        /// 处理咨询
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override ResultInfo Update(ConsultingInfo info)
        {
            if (info == null || info.Id <= 0)
                return new ResultInfo(0, "未找到相应的咨询！");
            using (var db = new EFDbContext())
            {
                var item =
                    db.Consultings.FirstOrDefault(t => t.ConsultingId == info.Id);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的咨询！");
                item.DeelSituation = info.DeelSituation;
                item.DeelTime = DateTime.Now;
                item.State = (byte) StateType.Display;
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
                return new ResultInfo(0, "未找到相应的咨询！");
            using (var db = new EFDbContext())
            {
                var list = db.Consultings.Where(t => ids.Contains(t.ConsultingId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的咨询！");
                foreach (var item in list)
                {
                    item.State = (byte)state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public override ConsultingInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Consultings.FirstOrDefault(t => t.ConsultingId == id);
                if (item == null) return null;
                return new ConsultingInfo
                {
                    Id = item.ConsultingId,
                    Title = item.Title,
                    Content = item.Content,
                    Contact = item.Contact,
                    Mobile = item.Mobile,
                    DeelSituation = item.DeelSituation,
                    DeelTime = item.DeelTime,
                    State = item.State,
                    CreateOn = item.CreateOn
                };
            }
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关分类！");
            return new ResultInfo(1, "", new
                {
                    id = info.Id,
                    title = info.Title,
                    content = info.Content,
                    contact = info.Contact,
                    deel = info.DeelSituation,
                    deelTime = Const.FormatDate(info.DeelTime),
                    createOn = Const.FormatDate(info.CreateOn)
                });
        }
    }
}
