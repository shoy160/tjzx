using System.Collections.Generic;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFPackageCategoriesRepository : IPackageCategoryRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<PackageCategory> Values
        {
            get { return _context.PackageCategories; }
        }
    }
}
