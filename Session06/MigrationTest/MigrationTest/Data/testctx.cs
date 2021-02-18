using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MigrationTest.Models;

#nullable disable

namespace MigrationTest.Data
{
    public partial class testctx : DbContext
    {
        public testctx()
        {
        }

        public testctx(DbContextOptions<testctx> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseTag> CourseTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.,1733; Database=BeginingEfCore5Db; User Id=sa; Password=1qaz!QAZ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasIndex(e => e.CourseId, "IX_Comment_CourseId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CourseId);
            });

            modelBuilder.Entity<CourseTag>(entity =>
            {
                entity.HasKey(e => new { e.CoursesId, e.TagsId });

                entity.ToTable("CourseTag");

                entity.HasIndex(e => e.TagsId, "IX_CourseTag_TagsId");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.CourseTags)
                    .HasForeignKey(d => d.CoursesId);

                entity.HasOne(d => d.Tags)
                    .WithMany(p => p.CourseTags)
                    .HasForeignKey(d => d.TagsId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
