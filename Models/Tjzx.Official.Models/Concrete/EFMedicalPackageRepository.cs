using System.Collections.Generic;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFMedicalPackageRepository:IMedicalPackagesRepository
    {
        private readonly EFDbContext _context = new EFDbContext();
        public IEnumerable<MedicalPackage> MedicalPackages
        {
            get { return _context.MedicalPackages; }
        }
    }
}
