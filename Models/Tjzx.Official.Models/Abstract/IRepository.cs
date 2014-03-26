using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    /// <summary>
    /// 体检套餐 职责链模式
    /// </summary>
    public interface IRepository
    {
        IEnumerable<PackageCategory> PackageCategories { get; }
        IEnumerable<MedicalPackage> MedicalPackages { get; }
        IEnumerable<Reservation> Reservations { get; }
        IEnumerable<News> Newses { get; }
    }
}
