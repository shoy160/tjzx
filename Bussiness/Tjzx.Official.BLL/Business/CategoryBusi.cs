using System;
using System.Linq;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    /// <summary>
    /// 套餐分类 业务逻辑
    /// </summary>
    public class CategoryBusi:BusiBase<CategoryInfo>
    {
        public override ResultInfo Insert(CategoryInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new PackageCategory
                    {
                        Name = info.Name,
                        State = info.State,
                        Sort = info.Sort,
                        CreateOn = DateTime.Now
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.PackageCategories.Add(item);
                    db.SaveChanges();
                    return new ResultInfo(1);
                }
                var msg = valid.ValidationErrors.FirstOrDefault();
                if (msg != null)
                    return new ResultInfo(0, msg.ErrorMessage);
                return new ResultInfo(0, "数据异常，请重试！");
            }
        }

        public override ResultInfo Update(CategoryInfo info)
        {
            if (info == null || info.CateId <= 0)
                return new ResultInfo(0, "未找到相应的套餐分类！");
            using (var db = new EFDbContext())
            {
                var item = db.PackageCategories.FirstOrDefault(t => t.CategoryId == info.CateId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的套餐分类！");
                item.Name = info.Name;
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

        public override ResultInfo GetList(SearchInfo info)
        {
            using (var db = new EFDbContext())
            {
                var count = db.PackageCategories.Count(t =>
                    (string.IsNullOrEmpty(info.Keyword) || t.Name.Contains(info.Keyword)) &&
                    (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.PackageCategories.Where(
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
                              count = t.MedicalPackages.Count,
                              createon = Const.FormatDate(t.CreateOn),
                              state = t.State,
                              stateCN = ((StateType)t.State).GetCssText()
                          }).ToList();
                return new ResultInfo(1, "", new {count, list});
            }
        }

        public override ResultInfo UpdateState(int[] ids, StateType state)
        {
            if (ids == null || ids.Length == 0)
                return new ResultInfo(0, "未找到相应的套餐分类！");
            using (var db = new EFDbContext())
            {
                var list = db.PackageCategories.Where(t => ids.Contains(t.CategoryId));
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

        public override CategoryInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.PackageCategories.FirstOrDefault(t => t.CategoryId == id);
                if (item == null) return null;
                return new CategoryInfo
                    {
                        CateId = item.CategoryId,
                        Name = item.Name,
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
                    cateId = info.CateId,
                    name = info.Name,
                    sort = info.Sort,
                    state = info.State
                });
        }
    }
}
