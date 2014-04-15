using System;
using System.Linq;
using Shoy.Utility;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    public class ReservationBusi:BusiBase<ReservationInfo>
    {
        /// <summary>
        /// 提交预约信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override ResultInfo Insert(ReservationInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new Reservation
                    {
                        Name = info.Name,
                        Mobile = info.Mobile,
                        IdNumber = info.IdNumber,
                        Email = info.Email,
                        Remark = info.Remark,
                        Company = info.Company,
                        Address = info.Address,
                        Type = info.Type,
                        PackageId = info.PackageId,
                        ReservationDate = info.ReservationDate,
                        CreatorIp = Utils.GetRealIp(),
                        State = (byte) StateType.Hidden,
                        CreateOn = DateTime.Now
                    };
                var user = User.GetUser();
                if (user != null && user.Type == UserType.Member.GetValue())
                    item.MemberId = user.UserId;
                else
                {
                    //Todo:创建普通用户？
                }
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.Reservations.Add(item);
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
                var count = db.Reservations.Count(
                    t =>
                    (string.IsNullOrEmpty(info.Keyword) ||
                     t.Name.Contains(info.Keyword)) &&
                    (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.Reservations.Where(
                        t => (string.IsNullOrEmpty(info.Keyword) ||
                              t.Name.Contains(info.Keyword)) &&
                             (info.State == Const.Ignore || t.State == info.State))
                      .OrderByDescending(t => t.PackageId)
                      .ThenBy(t => t.State)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.ReservationId,
                              name = t.Name,
                              mobile = t.Mobile,
                              packageId=t.PackageId,
                              packageName = GetPackage(t.PackageId),
                              type = t.Type,
                              typeCN = ((ReservationType) t.Type).GetEnumCssText(),
                              reservationDate = Const.FormatDate(t.ReservationDate),
                              createon = Const.FormatDate(t.CreateOn),
                              state = t.State,
                              stateCN = ((StateType) t.State).ConsultingStateCssText()
                          }).ToList();
                return new ResultInfo(1, "", new { count, list });
            }
        }

        private string GetPackage(int packageId)
        {
            if (packageId <= 0) return Const.DefaultPackageName;
            var busi = new PackageBusi();
            var item = busi.GetItem(packageId);
            if (item != null) return item.Name;
            return Const.DefaultPackageName;
        }

        public override ResultInfo Update(ReservationInfo info)
        {
            throw new NotImplementedException();
        }

        public override ResultInfo UpdateState(int[] ids, StateType state)
        {
            if (ids == null || ids.Length == 0)
                return new ResultInfo(0, "未找到相应的咨询！");
            using (var db = new EFDbContext())
            {
                var list = db.Reservations.Where(t => ids.Contains(t.ReservationId));
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

        public override ReservationInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Reservations.FirstOrDefault(t => t.ReservationId == id);
                if (item == null) return null;
                return new ReservationInfo
                    {
                        ReservationId = item.ReservationId,
                        Name = item.Name,
                        Mobile = item.Mobile,
                        IdNumber = item.IdNumber,
                        Company = item.Company,
                        Address = item.Address,
                        Email = item.Email,
                        CreateOn = item.CreateOn,
                        Remark = item.Remark,
                        ReservationDate = item.ReservationDate,
                        Type = item.Type,
                        State = item.State,
                        MemberId = item.MemberId,
                        PackageId = item.PackageId
                    };
            }
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关预约信息！");
            return new ResultInfo(1, "", new
                {
                    reservationId = info.ReservationId,
                    name = info.Name,
                    mobile = info.Mobile,
                    idNumber = info.IdNumber,
                    company = info.Company,
                    address = info.Address,
                    email = info.Email,
                    remark = info.Remark,
                    packageId = info.PackageId,
                    packageName = GetPackage(info.PackageId),
                    type = info.Type,
                    typeCN = ((ReservationType) info.Type).GetEnumCssText(),
                    reservationDate = Const.FormatDate(info.ReservationDate),
                    createOn = Const.FormatDate(info.CreateOn),
                    state = info.State,
                    stateCN = ((StateType) info.State).ConsultingStateCssText()
                });
        }
    }
}
