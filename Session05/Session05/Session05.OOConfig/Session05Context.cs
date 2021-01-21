using Microsoft.EntityFrameworkCore;
using Session05.OOConfig.Inheritance;
using Session05.OOConfig.Owned;
using Session05.OOConfig.TableSplit;
using System;

namespace Session05.OOConfig
{
    public class Session05Context : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsDetail> NewsDetail { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.,1733;Database=Session05Db; User Id=sa; Password=1qaz!QAZ")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasDiscriminator<PersonType>(c => c.PersonType)
            //    .HasValue<Student>(PersonType.Student)
            //    .HasValue<Teacher>(PersonType.Teacher);
            //modelBuilder.Entity<Person>().OwnsMany(c => c.Address, d =>
            //{
            //    //d.Property(a => a.City).HasColumnName("City");
            //    //d.Property(a => a.Proviance).HasColumnName("Proviance");
            //    //d.Property(a => a.Street).HasColumnName("Street");
            //    //d.Property(a => a.Phone).HasColumnName("Phone");
            //    d.ToTable("Address");

            //});

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");

            modelBuilder.Entity<News>().HasOne(c => c.NewsDetail).WithOne().HasForeignKey<NewsDetail>(c => c.Id);
            modelBuilder.Entity<NewsDetail>().ToTable("News");

        }
    }
}
