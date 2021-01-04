using CourseStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseStore.Infra.Dal
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().ToTable("Comment");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SoftDeletable>().HasQueryFilter(c => c.IsDeleted == false);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SoftDeletable> SoftDeletables { get; set; }
        public DbSet<RootObject> RootObjects { get; set; }

    }

}
