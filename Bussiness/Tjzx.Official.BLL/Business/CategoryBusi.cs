using System.Linq;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.BLL.Business
{
    /// <summary>
    /// 套餐分类 业务逻辑
    /// </summary>
    public class CategoryBusi
    {
        public static ResultInfo Insert(CategoryInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new PackageCategory
                    {
                        Name = info.Name,
                        Sort = info.Sort
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

        public static ResultInfo Update(CategoryInfo info)
        {
            if (info == null || info.CategoryId <= 0)
                return new ResultInfo(0, "未找到相应的套餐分类！");
            using (var db = new EFDbContext())
            {
                var item = db.PackageCategories.FirstOrDefault(t => t.CategoryId == info.CategoryId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的套餐分类！");
                item.Name = info.Name;
                item.Sort = info.Sort;
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

        public static ResultInfo UpdateState(int categoryId, StateType state)
        {
            if (categoryId <= 0)
                return new ResultInfo(0, "未找到相应的套餐分类！");
            using (var db = new EFDbContext())
            {
                var item = db.PackageCategories.FirstOrDefault(t => t.CategoryId == categoryId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的套餐分类！");
                item.State = (byte) state;
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public static ResultInfo GetList(byte state)
        {
            using (var db = new EFDbContext())
            {
                var list = db.PackageCategories.Where(t => (state == Const.Ignore || t.State == state))
                             .OrderBy(t => t.Sort)
                             .ToList();
                return new ResultInfo(1, "", new {count = list.Count, list});
            }
        }
    }
}
