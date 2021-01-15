using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;

namespace Session4.Configurations
{

    public class MyDbContextTest : DbContext
    {
        public DbSet<FirstEntityAttribute> FirstEntityAttributes { get; set; }
        public DbSet<TestValueConversion> TestValueConversions { get; set; }
        //public DbSet<PkTestAttribute> PkTestAttributes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.,1733;Database=TestConfig; User Id=sa; Password=1qaz!QAZ");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Ignore(typeof(FirstNotMappedFluent));
            modelBuilder.Entity<FirstEntityFluent>().Ignore(c => c.FullName);
            modelBuilder.Entity<FirstEntityFluent>().Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<FirstEntityFluent>().Property(c => c.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<FirstEntityFluent>().Property(c => c.BirthDate).HasColumnType("Date");

            modelBuilder.Entity<TestValueConversion>().Property(c => c.ValueConversionInner).
                HasConversion(c => JsonConvert.SerializeObject(c), d => JsonConvert.DeserializeObject<ValueConversionInner>(d));

            modelBuilder.Entity<PkTestFluent>().HasKey(c => new { c.Pk01, c.Pk02 });

            modelBuilder.Entity<KeyLessFluentSample>().HasNoKey();

            modelBuilder.Entity<FirstEntityFluent>().HasIndex(c => new { c.FirstName, c.LastName }).HasFilter("");

        }
    }
}
