using CourseContentManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseContentManagement.Data
{
    public class CourseContentDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<InfoPage> InfoPages { get; set; }
        public CourseContentDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(DefaultData.Courses);

            modelBuilder.Entity<Section>().HasData(DefaultData.Sections);

            modelBuilder.Entity<InfoPage>().HasData(DefaultData.InfoPages);
        }
    }
}