using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _04DataFirstCore.Models
{
    public partial class CodeFirstDBContext : DbContext
    {
        public CodeFirstDBContext()
        {
        }

        public CodeFirstDBContext(DbContextOptions<CodeFirstDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CodeFirstDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.TeacherId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.TeacherId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
