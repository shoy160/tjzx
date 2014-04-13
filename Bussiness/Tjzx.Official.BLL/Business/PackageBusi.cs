using System;
using System.Linq;
using System.Text;
using Shoy.Utility;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    public class PackageBusi:BusiBase<PackageInfo>
    {
        public override ResultInfo Insert(PackageInfo info)
        {
            using (var db = new EFDbContext())
            {
                var user = User.GetUser();
                var details = Utils.UrlDecode(info.Details, Encoding.UTF8);
                var item = new MedicalPackage
                    {
                        Name = info.Name,
                        Picture = info.Picture,
                        CategoryId = info.CategoryId,
                        Sex = info.Sex,
                        MarketPrice = 0,
                        Price = 0,
                        Type = info.Type,
                        ForTheCrowd = info.ForTheCrowd,
                        Feature = info.Feature,
                        Recommends = info.Recommends??"recommends",
                        Details = details,
                        State = info.State,
                        Sort = info.Sort,
                        CreateOn = DateTime.Now,
                        CreatorId = user.UserId,
                        Creator = user.UserName
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.MedicalPackages.Add(item);
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
                var count = db.MedicalPackages.Count(t =>
                                                     (string.IsNullOrEmpty(info.Keyword) ||
                                                      t.Name.Contains(info.Keyword)) &&
                                                     (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.MedicalPackages.Where(
                        t => (string.IsNullOrEmpty(info.Keyword) ||
                              t.Name.Contains(info.Keyword)) &&
                             (info.State == Const.Ignore || t.State == info.State))
                      .OrderBy(t => t.Sort)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.CategoryId,
                              name = t.Name,
                              picture=t.Picture,
                              category = t.Category.Name,
                              sex = t.Sex,
                              ftc = t.ForTheCrowd,
                              feature = t.Feature,
                              createon = Const.FormatDate(t.CreateOn),
                              state = t.State,
                              stateCN = ((StateType) t.State).GetCssText()
                          }).ToList();
                return new ResultInfo(1, "", new {count, list});
            }
        }

        public override ResultInfo Update(PackageInfo info)
        {
            if (info == null || info.PackageId <= 0)
                return new ResultInfo(0, "未找到相应的套餐！");
            using (var db = new EFDbContext())
            {
                var item = db.MedicalPackages.FirstOrDefault(t => t.PackageId == info.PackageId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的套餐分类！");
                var details = Utils.UrlDecode(info.Details, Encoding.UTF8);
                item.Name = info.Name;
                item.Picture = info.Picture;
                item.CategoryId = info.CategoryId;
                item.Sex = info.Sex;
                item.Type = info.Type;
                item.ForTheCrowd = info.ForTheCrowd;
                item.Feature = info.Feature;
                item.Recommends = info.Recommends ?? "recommends";
                item.Details = details;
                item.Sort = info.Sort;
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
                return new ResultInfo(0, "未找到相应的套餐分类！");
            using (var db = new EFDbContext())
            {
                var list = db.MedicalPackages.Where(t => ids.Contains(t.PackageId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的套餐分类！");
                foreach (var item in list)
                {
                    item.State = (byte) state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public override PackageInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.MedicalPackages.FirstOrDefault(t => t.PackageId == id);
                if (item == null) return null;
                return new PackageInfo
                    {
                        PackageId = item.PackageId,
                        CategoryId = item.CategoryId,
                        Name = item.Name,
                        Picture = item.Picture,
                        Sex = item.Sex,
                        ForTheCrowd = item.ForTheCrowd,
                        Feature = item.Feature,
                        Recommends = item.Recommends,
                        Details = item.Details,
                        State = item.State,
                        Sort = item.Sort,
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
                    packageId = info.PackageId,
                    cateId = info.CategoryId,
                    name = info.Name,
                    picture = info.Picture,
                    sex = info.Sex,
                    ftc = info.ForTheCrowd,
                    feature = info.Feature,
                    recommends = info.Recommends,
                    details = info.Details,
                    sort = info.Sort,
                    state = info.State
                });
        }
    }
}
