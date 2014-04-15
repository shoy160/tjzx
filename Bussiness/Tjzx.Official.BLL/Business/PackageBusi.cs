using System;
using System.Linq;
using System.Text;
using Shoy.Utility;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;
using System.IO;
using System.Security.AccessControl;

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
                        Recommends = info.Recommends ?? "recommends",
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
                    var picture = CheckImage(item.PackageId, item.CreateOn, item.Picture);
                    if (!string.IsNullOrEmpty(picture))
                    {
                        item.Picture = picture;
                        db.SaveChanges();
                    }
                    return new ResultInfo(1);
                }
                var msg = valid.ValidationErrors.FirstOrDefault();
                if (msg != null)
                    return new ResultInfo(0, msg.ErrorMessage);
                return new ResultInfo(0, "数据异常，请重试！");
            }
        }

        private string CheckImage(int packageId, DateTime createOn, string picture)
        {
            string result = string.Empty;
            if (packageId <= 0 || string.IsNullOrEmpty(picture) || picture.Contains("/" + packageId + "/"))
                return result;
            string name = Path.GetFileName(picture),
                   path = Utils.GetMapPath(picture),
                   newUrl = "/upload/" + Const.PackageImageDirectory + "/" +
                            createOn.ToString("yyyyMM") + "/" + packageId + "/",
                   newPath = Utils.GetMapPath(newUrl);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            try
            {
                File.Move(path, newPath + name);
                return newUrl + name;
            }
            catch
            {
                return result;
            }
        }

        public override ResultInfo GetList(SearchInfo info)
        {
            using (var db = new EFDbContext())
            {
                var count = db.MedicalPackages.Count(
                    t =>
                    (string.IsNullOrEmpty(info.Keyword) ||
                     t.Name.Contains(info.Keyword)) &&
                    (info.CategoryId == Const.Ignore || t.CategoryId == info.CategoryId) &&
                    (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.MedicalPackages.Where(
                        t => (string.IsNullOrEmpty(info.Keyword) ||
                              t.Name.Contains(info.Keyword)) &&
                             (info.CategoryId == Const.Ignore || t.CategoryId == info.CategoryId) &&
                             (info.State == Const.Ignore || t.State == info.State))
                      .OrderByDescending(t => t.PackageId)
                      .ThenBy(t => t.Sort)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.PackageId,
                              name = t.Name,
                              picture = t.Picture,
                              category = t.Category.Name,
                              sex = (t.Sex == 3 ? "不限" : t.Sex == 2 ? "男士" : "女士"),
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
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    var picture = CheckImage(item.PackageId, item.CreateOn, item.Picture);
                    if (!string.IsNullOrEmpty(picture))
                    {
                        item.Picture = picture;
                    }
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
                return new ResultInfo(0, "未找到相关套餐！");
            return new ResultInfo(1, "", new
                {
                    packageId = info.PackageId,
                    categoryId = info.CategoryId,
                    name = info.Name,
                    picture = info.Picture,
                    sex = info.Sex,
                    forTheCrowd = info.ForTheCrowd,
                    feature = info.Feature,
                    recommends = info.Recommends,
                    details = info.Details,
                    sort = info.Sort,
                    state = info.State
                });
        }
    }
}
