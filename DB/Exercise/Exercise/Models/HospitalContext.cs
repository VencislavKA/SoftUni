using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exercise.Models
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diagnose> Diagnose { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Visitation> Visitation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning        To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Hospital;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Diagnose)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("FK__Diagnose__Patien__29572725");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(250);

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Visitation)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("FK__Visitatio__Patie__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
