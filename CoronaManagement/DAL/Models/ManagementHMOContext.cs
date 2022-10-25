using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class ManagementHMOContext : DbContext
    {
        public ManagementHMOContext()
        {
        }

        public ManagementHMOContext(DbContextOptions<ManagementHMOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoronaVaccine> CoronaVaccines { get; set; }
        public virtual DbSet<ListOpatient> ListOpatients { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<VaccineManufacturer> VaccineManufacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=ManagementHMO;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CoronaVaccine>(entity =>
            {
                entity.HasKey(e => e.LineCode)
                    .HasName("PK__CoronaVa__3BE93B9C45029851");

                entity.ToTable("CoronaVaccine");

                entity.Property(e => e.CounterV).HasColumnName("counterV");

                entity.Property(e => e.DateV).HasColumnType("date");

                entity.Property(e => e.ManufacturerId)
                    .HasMaxLength(10)
                    .HasColumnName("ManufacturerID")
                    .IsFixedLength(true);

                entity.Property(e => e.PatientId)
                    .HasMaxLength(9)
                    .HasColumnName("PatientID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.CoronaVaccines)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK__CoronaVac__count__3A81B327");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.CoronaVaccines)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__CoronaVac__Patie__3B75D760");
            });

            modelBuilder.Entity<ListOpatient>(entity =>
            {
                entity.HasKey(e => e.LineCode)
                    .HasName("PK__ListOPat__3BE93B9C4A014BA3");

                entity.ToTable("ListOPatients");

                entity.Property(e => e.DateNegative).HasColumnType("date");

                entity.Property(e => e.DatePositive).HasColumnType("date");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(9)
                    .HasColumnName("PatientID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ListOpatients)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__ListOPati__DateN__3E52440B");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId)
                    .HasMaxLength(9)
                    .HasColumnName("PatientID")
                    .IsFixedLength(true);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");
            });

            modelBuilder.Entity<VaccineManufacturer>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK_Table_1");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(10)
                    .HasColumnName("CompanyID")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
