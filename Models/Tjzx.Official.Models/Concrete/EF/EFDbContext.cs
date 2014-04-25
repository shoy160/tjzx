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

        /// <summary>
        /// 体检套餐
        /// </summary>
        public DbSet<MedicalPackage> MedicalPackages { get; set; }

        /// <summary>
        /// 套餐分类
        /// </summary>
        public DbSet<PackageCategory> PackageCategories { get; set; }

        /// <summary>
        /// 体检预约
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }

        /// <summary>
        /// 健康资讯
        /// </summary>
        public DbSet<News> Newses { get; set; }

        /// <summary>
        /// 会员
        /// </summary>
        public DbSet<Member> Members { get; set; }

        /// <summary>
        /// 咨询交流
        /// </summary>
        public DbSet<Consulting> Consultings { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// 相册
        /// </summary>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// 相册分组
        /// </summary>
        public DbSet<AlbumGroup> AlbumGroups { get; set; }
        
        /// <summary>
        /// 体检报告
        /// </summary>
        public DbSet<MedicalReport> Reports { get; set; }
    }
}
