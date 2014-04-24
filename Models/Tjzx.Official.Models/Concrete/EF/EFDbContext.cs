using System.Data.Entity;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=EFDbContext")
        {
        }

        static EFDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbContext>());
        }

        public DbSet<MedicalPackage> MedicalPackages { get; set; }

        public DbSet<PackageCategory> PackageCategories { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<News> Newses { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Consulting> Consultings { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}
