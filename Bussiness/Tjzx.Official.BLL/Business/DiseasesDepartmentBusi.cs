using System.Linq;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.BLL.Business
{
    /// <summary>
    /// 疾病分科业务逻辑类
    /// </summary>
    public class DiseasesDepartmentBusi : BusiBase<DiseasesDepartmentInfo>
    {
        public override ResultInfo Insert(DiseasesDepartmentInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new DiseasesDepartment
                    {
                        DiseasesDepartmentName = info.DiseasesDepartmentName,
                        State = info.State,
                        Sort = info.Sort
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.DiseasesDepartments.Add(item);
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
                var count = db.DiseasesDepartments.Count(
                    t =>
                    (string.IsNullOrEmpty(info.Keyword) ||
                     t.DiseasesDepartmentName.Contains(info.Keyword)) &&
                    (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.DiseasesDepartments.Where(
                        t => (string.IsNullOrEmpty(info.Keyword) ||
                              t.DiseasesDepartmentName.Contains(info.Keyword)) &&
                             (info.State == Const.Ignore || t.State == info.State))
                      .OrderByDescending(t => t.DiseasesDepartmentId)
                      .ThenBy(t => t.Sort)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.DiseasesDepartmentId,
                              name = t.DiseasesDepartmentName,
                              count = t.Diseaseses.Count,
                              state = t.State,
                              stateCN = ((StateType) t.State).GetCssText()
                          }).ToList();
                return new ResultInfo(1, "", new {count, list});
            }
        }

        public override ResultInfo Update(DiseasesDepartmentInfo info)
        {
            if (info == null || info.DiseasesDepartmentId <= 0)
                return new ResultInfo(0, "未找到相应的疾病分科！");
            using (var db = new EFDbContext())
            {
                var item =
                    db.DiseasesDepartments.FirstOrDefault(t => t.DiseasesDepartmentId == info.DiseasesDepartmentId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的疾病分科！");
                item.DiseasesDepartmentName = info.DiseasesDepartmentName;
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
                return new ResultInfo(0, "未找到相应的疾病分科！");
            using (var db = new EFDbContext())
            {
                var list = db.DiseasesDepartments.Where(t => ids.Contains(t.DiseasesDepartmentId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的疾病分科！");
                foreach (var item in list)
                {
                    item.State = (byte)state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public override DiseasesDepartmentInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.DiseasesDepartments.FirstOrDefault(t => t.DiseasesDepartmentId == id);
                if (item == null) return null;
                return new DiseasesDepartmentInfo
                    {
                        DiseasesDepartmentId = item.DiseasesDepartmentId,
                        DiseasesDepartmentName = item.DiseasesDepartmentName,
                        State = item.State,
                        Sort = item.Sort
                    };
            }
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关疾病分科！");
            return new ResultInfo(1, "", new
                {
                    diseasesDepartmentId = info.DiseasesDepartmentId,
                    diseasesDepartmentName = info.DiseasesDepartmentName,
                    sort = info.Sort,
                    state = info.State
                });
        }
    }
}
