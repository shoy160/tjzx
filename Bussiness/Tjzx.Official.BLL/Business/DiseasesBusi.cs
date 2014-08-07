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
    /// <summary>
    /// 疾病业务逻辑类
    /// </summary>
    public class DiseasesBusi:BusiBase<DiseasesInfo>
    {
        public override ResultInfo Insert(DiseasesInfo info)
        {
            using (var db = new EFDbContext())
            {
                var item = new Diseases
                    {
                        DiseasesName = info.DiseasesName,
                        DiseasesDepartmentId = info.DiseasesDepartmentId,
                        DiseasesDescription = Utils.UrlDecode(info.DiseasesDescription, Encoding.UTF8),
                        State = info.State,
                        Sort = info.Sort,
                        CreateOn = DateTime.Now,
                        CreatorId = info.CreatorId,
                        Creator = info.Creator
                    };
                var valid = db.Entry(item).GetValidationResult();
                if (valid.IsValid)
                {
                    db.Diseaseses.Add(item);
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
                var count = db.Diseaseses.Count(
                    t =>
                    (string.IsNullOrEmpty(info.Keyword) ||
                     t.DiseasesName.Contains(info.Keyword)) &&
                    (info.CategoryId == Const.Ignore || t.DiseasesDepartmentId == info.CategoryId) &&
                    (info.State == Const.Ignore || t.State == info.State));
                var list =
                    db.Diseaseses.Where(
                        t => (string.IsNullOrEmpty(info.Keyword) ||
                              t.DiseasesName.Contains(info.Keyword)) &&
                             (info.CategoryId == Const.Ignore || t.DiseasesDepartmentId == info.CategoryId) &&
                             (info.State == Const.Ignore || t.State == info.State))
                      .OrderByDescending(t => t.DiseasesId)
                      .ThenBy(t => t.Sort)
                      .Skip(info.Page*info.Size)
                      .Take(info.Size)
                      .ToList()
                      .Select(t => new
                          {
                              id = t.DiseasesId,
                              name = t.DiseasesName,
                              departmentName = t.DiseasesDepartment.DiseasesDepartmentName,
                              createon = Const.FormatDate(t.CreateOn),
                              state = t.State,
                              stateCN = ((StateType) t.State).GetCssText()
                          }).ToList();
                return new ResultInfo(1, "", new { count, list });
            }
        }

        public override ResultInfo Update(DiseasesInfo info)
        {
            if (info == null || info.DiseasesId <= 0)
                return new ResultInfo(0, "未找到相应的疾病！");
            using (var db = new EFDbContext())
            {
                var item =
                    db.Diseaseses.FirstOrDefault(t => t.DiseasesId == info.DiseasesId);
                if (item == null)
                    return new ResultInfo(0, "未找到相应的疾病！");
                item.DiseasesName = info.DiseasesName;
                item.DiseasesDepartmentId = info.DiseasesDepartmentId;
                item.DiseasesDescription = Utils.UrlDecode(info.DiseasesDescription, Encoding.UTF8);
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
            if (ids.Length <= 0)
                return new ResultInfo(0, "未找到相应的疾病！");
            using (var db = new EFDbContext())
            {
                var list = db.Newses.Where(t => ids.Contains(t.NewsId));
                if (!list.Any())
                    return new ResultInfo(0, "未找到相应的疾病！");
                foreach (var item in list)
                {
                    item.State = (byte)state;
                }
                db.SaveChanges();
                return new ResultInfo(1);
            }
        }

        public override DiseasesInfo GetItem(int id)
        {
            using (var db = new EFDbContext())
            {
                var item = db.Diseaseses.FirstOrDefault(t => t.DiseasesId == id);
                if (item == null) return null;
                return new DiseasesInfo
                    {
                        DiseasesId = item.DiseasesId,
                        DiseasesDepartmentId = item.DiseasesDepartmentId,
                        DepartmentName = item.DiseasesDepartment.DiseasesDepartmentName,
                        DiseasesName = item.DiseasesName,
                        DiseasesDescription = item.DiseasesDescription,
                        State = item.State,
                        Sort = item.Sort,
                        CreateOn = item.CreateOn,
                        CreatorId = item.CreatorId,
                        Creator = item.Creator
                    };
            }
        }

        public override ResultInfo Item(int id)
        {
            var info = GetItem(id);
            if (info == null)
                return new ResultInfo(0, "未找到相关疾病！");
            return new ResultInfo(1, "", new
                {
                    diseasesId = info.DiseasesId,
                    diseasesDepartmentId = info.DiseasesDepartmentId,
                    departmentName = info.DepartmentName,
                    diseasesName = info.DiseasesName,
                    diseasesDescription = info.DiseasesDescription,
                    state = info.State,
                    sort = info.Sort,
                    CreateOn = Const.FormatDate(info.CreateOn)
                });
        }

        public ResultInfo GetDepartmentList(int state)
        {
            using (var db = new EFDbContext())
            {
                var list = (from dp in db.DiseasesDepartments
                            where (state == Const.Ignore || dp.State == state)
                            select new
                                {
                                    dp.DiseasesDepartmentId,
                                    dp.DiseasesDepartmentName
                                }).Select(t => new
                                    {
                                        id = t.DiseasesDepartmentId,
                                        name = t.DiseasesDepartmentName
                                    }).ToList();
                return new ResultInfo(1, "", new {count = list.Count, list});
            }
        }
    }
}
