using System.Collections.Generic;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFRepository : IRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<MedicalPackage> MedicalPackages
        {
            get { return _context.MedicalPackages; }
        }

        public IEnumerable<PackageCategory> PackageCategories
        {
            get { return _context.PackageCategories; }
        }

        public IEnumerable<Reservation> Reservations
        {
            get { return _context.Reservations; }
        }

        public IEnumerable<News> Newses
        {
            get { return _context.Newses; }
        }
    }
}
