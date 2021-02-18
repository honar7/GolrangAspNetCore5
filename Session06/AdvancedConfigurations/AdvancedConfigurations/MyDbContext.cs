using Microsoft.EntityFrameworkCore;
using System;

namespace AdvancedConfigurations
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<BankAccout> BankAccouts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.,1733; Database=MyDbContextDb;User Id=sa; Password=1qaz!QAZ")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDbFunction(() => MyFunctions.GetMaxAge(int.MinValue));

            //modelBuilder.HasSequence("MySequence", c =>
            //{
            //    //c.HasMax(100);
            //    //c.HasMin(50);
            //    //c.IsCyclic(true);
            //    c.IncrementsBy(10);
            //    //c.StartsAt(55);

            //});

            //modelBuilder.Entity<Person>().Property(c => c.FullName).HasComputedColumnSql("FirstName + ', '+ LastName");

            ////modelBuilder.Entity<Person>().Property(c => c.FavoritColor).HasDefaultValue("Not Set");
            //modelBuilder.Entity<Person>().Property(c => c.FavoritColor).HasValueGenerator<MyValueGenerator>();
            //modelBuilder.Entity<Person>().Property(c => c.SequenceValue).HasDefaultValueSql("Next value for MySequence");
            ////modelBuilder.Entity<Person>().Property(c => c.FirstName).ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<BankAccout>().Property(c => c.Value).IsConcurrencyToken();


            base.OnModelCreating(modelBuilder);
        }
        //[DbFunction]
        //public  IQueryable<PersonDto> GetAll()
        //{
        //    return FromExpression<PersonDto>(() => GetAll());
        //}

        //[DbFunction]
        //public static int GetMaxAge2(int minAge)
        //{
        //    return default;
        //}
    }
}
