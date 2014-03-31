using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    /// <summary>
    /// 体检套餐 职责链模式
    /// </summary>
    public interface IMedicalPackageRepository
    {
        IEnumerable<MedicalPackage> Values { get; }
    }
}
