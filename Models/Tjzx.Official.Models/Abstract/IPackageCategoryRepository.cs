using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    /// <summary>
    /// 套餐分类 职责链模式
    /// </summary>
    public interface IPackageCategoryRepository
    {
        IEnumerable<PackageCategory> Values { get; }
    }
}
