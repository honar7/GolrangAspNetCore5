using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using MigrationTest.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MigrationTest
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.,1733;Database =MyDbContextDb;User Id=sa; Password=1qaz!QAZ", c =>
             {
                 c.MigrationsHistoryTable("MyHistoryTable");
             })
                .ReplaceService<SqlServerMigrationsSqlGenerator, GolrangSqlMigrationGenerator>()
                .ReplaceService<IHistoryRepository, TempHistory>();
        }

        public class MyHistory : SqlServerHistoryRepository
        {
            public MyHistory([NotNullAttribute] HistoryRepositoryDependencies dependencies) : base(dependencies)
            {
            }
            protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
            {
                history.Property(c => c.ProductVersion).HasColumnName("MyProductVersion").IsRequired();
                base.ConfigureTable(history);
            }
        }

        public class TempHistory : IHistoryRepository
        {
            public bool Exists()
            {
                throw new NotImplementedException();
            }

            public Task<bool> ExistsAsync(CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public IReadOnlyList<HistoryRow> GetAppliedMigrations()
            {
                throw new NotImplementedException();
            }

            public Task<IReadOnlyList<HistoryRow>> GetAppliedMigrationsAsync(CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public string GetBeginIfExistsScript(string migrationId)
            {
                throw new NotImplementedException();
            }

            public string GetBeginIfNotExistsScript(string migrationId)
            {
                throw new NotImplementedException();
            }

            public string GetCreateIfNotExistsScript()
            {
                throw new NotImplementedException();
            }

            public string GetCreateScript()
            {
                throw new NotImplementedException();
            }

            public string GetDeleteScript(string migrationId)
            {
                throw new NotImplementedException();
            }

            public string GetEndIfScript()
            {
                throw new NotImplementedException();
            }

            public string GetInsertScript(HistoryRow row)
            {
                throw new NotImplementedException();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().ToTable("Books", c =>
            // {
            //     c.ExcludeFromMigrations();
            // });
            base.OnModelCreating(modelBuilder);

        }
    }
}
