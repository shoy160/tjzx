using System.Linq;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    public interface IPackageCategoriesRepository
    {
        IQueryable<PackageCategory> PackageCategories { get; } 
    }
}
