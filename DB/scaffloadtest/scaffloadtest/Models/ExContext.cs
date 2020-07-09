using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace scaffloadtest.Models
{
    public partial class ExContext : DbContext
    {
        public ExContext()
        {
        }

        public ExContext(DbContextOptions<ExContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<ItemTypes> ItemTypes { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<Models> Models { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Passports> Passports { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsExams> StudentsExams { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Ex;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__Cities__F2D21A9640B6ABB1");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B88EEDE5C8");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Customers__CityI__04E4BC85");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FirstName).HasColumnType("text");

                entity.Property(e => e.Lastname).HasColumnType("text");
            });

            modelBuilder.Entity<Exams>(entity =>
            {
                entity.HasKey(e => e.ExamId)
                    .HasName("PK__Exams__297521A73DD571F3");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ItemTypes>(entity =>
            {
                entity.HasKey(e => e.ItemTypeId)
                    .HasName("PK__ItemType__F51540DB21D514E8");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__Items__727E83EB3359209A");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK__Items__ItemTypeI__00200768");
            });

            modelBuilder.Entity<Manufacturers>(entity =>
            {
                entity.HasKey(e => e.ManufacturerId)
                    .HasName("PK__Manufact__357E5CA18ABD1DBF");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.EstablishedOn).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Models>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK__Models__E8D7A1CCDBC8969C");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK__Models__Manufact__6B24EA82");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Item)
                    .WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__OrderItem__ItemI__0B91BA14");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__Order__0A9D95DB");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAF54ED6517");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__08B54D69");
            });

            modelBuilder.Entity<Passports>(entity =>
            {
                entity.HasKey(e => e.PassportId)
                    .HasName("PK__Passport__185653F0000AFF94");

                entity.Property(e => e.PassportId).HasColumnName("PassportID");

                entity.Property(e => e.PassportNumber).HasColumnType("text");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__Persons__AA2FFB852F02CE71");

                entity.HasIndex(e => e.PassportId)
                    .HasName("UQ__Persons__185653F135FD6E9A")
                    .IsUnique();

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PassportId).HasColumnName("PassportID");

                entity.HasOne(d => d.Passport)
                    .WithOne(p => p.Persons)
                    .HasForeignKey<Persons>(d => d.PassportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Persons__Passpor__6383C8BA");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Students__32C52A792DD43556");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentsExams>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.ExamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Exam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentsEx__Exam__74AE54BC");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentsE__Stude__73BA3083");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PK__Teachers__EDF25944A8B0AFBD");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Teachers__Manage__778AC167");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
