using HelloEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloEF.DAL
{
    public class CourseDbContext :DbContext
    {
        public DbSet<Course>  Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQL2019;Database = GolrangDb; Integrated Security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
