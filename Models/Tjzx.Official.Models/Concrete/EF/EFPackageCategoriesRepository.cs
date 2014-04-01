using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFPackageCategoriesRepository : EFRepositoryBase<PackageCategory>
    {
        public override IEnumerable<PackageCategory> GetValues()
        {
            return Context.PackageCategories;
        }
    }
}
