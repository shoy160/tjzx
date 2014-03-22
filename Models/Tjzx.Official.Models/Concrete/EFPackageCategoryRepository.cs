using System.Linq;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFPackageCategoryRepository:IPackageCategoriesRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IQueryable<PackageCategory> PackageCategories
        {
            get
            {
                if (_context.PackageCategories != null) return _context.PackageCategories;
                return null;
            }
        }
    }
}
