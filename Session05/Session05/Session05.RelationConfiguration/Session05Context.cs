using Microsoft.EntityFrameworkCore;
using Session05.RelationConfiguration.Attibutes;
using Session05.RelationConfiguration.Fluens;
using Session05.RelationConfiguration.Principals;
using System;

namespace Session05.RelationConfiguration
{
    public class Session05Context : DbContext
    {
        public DbSet<ParentAttr> ParentAttrs { get; set; }
        public DbSet<ParentFl> parentFls { get; set; }
        public DbSet<ChidlFl> ChidlFls { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.,1733;Database=Session05Db; User Id=sa; Password=1qaz!QAZ")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChidlFl>().HasOne(c => c.ParentFl).WithMany(c => c.ChidlFls);
            modelBuilder.Entity<ParentFl>().HasMany(c => c.ChidlFls).WithOne(c => c.ParentFl);

            modelBuilder.Entity<OneParent>().HasOne(c => c.Child).WithOne().HasForeignKey<OneChild>(c => c.Id).IsRequired();
            //modelBuilder.Entity<RelationManyToMany>().HasOne(c => c.ManyLeft).WithMany(c => c.RelationManyToMany);
            //modelBuilder.Entity<RelationManyToMany>().HasOne(c => c.ManyRight).WithMany(c => c.RelationManyToMany);

            modelBuilder.Entity<ManyLeft>().HasMany(c => c.Rights).WithMany(c => c.Lefts)
                .UsingEntity<RelationManyToMany>(
                    r => r.HasOne(c => c.ManyRight).WithMany(c => c.RelationManyToMany).HasForeignKey(c => c.ManyRightId),
                    l => l.HasOne(c => c.ManyLeft).WithMany(c => c.RelationManyToMany).HasForeignKey(c => c.ManyLeftId));

            modelBuilder.Entity<PChild>().HasOne(c => c.PPerson).WithMany().HasPrincipalKey(c => c.NationalCode).HasConstraintName("");



        }
    }
}
