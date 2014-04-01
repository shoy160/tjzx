using System.Collections.Generic;
using System.ComponentModel;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class TestPackageCategoriesRepository : IRepository<PackageCategory>
    {
        public IEnumerable<PackageCategory> Values
        {
            get { return new BindingList<PackageCategory>(); }
        }
    }
}
