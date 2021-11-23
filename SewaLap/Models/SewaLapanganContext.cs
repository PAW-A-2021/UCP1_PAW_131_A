using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SewaLap.Models
{
    public partial class SewaLapanganContext : DbContext
    {
        public SewaLapanganContext()
        {
        }

        public SewaLapanganContext(DbContextOptions<SewaLapanganContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Lapangan> Lapangans { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Admin");

                entity.Property(e => e.EmailAdmin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Email_Admin");

                entity.Property(e => e.PasswordAdmin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Password_Admin");

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("No_HP");
            });

            modelBuilder.Entity<Lapangan>(entity =>
            {
                entity.HasKey(e => e.IdLapangan);

                entity.ToTable("Lapangan");

                entity.Property(e => e.IdLapangan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Lapangan");

                entity.Property(e => e.NamaLapangan)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Lapangan");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdLapangan).HasColumnName("ID_Lapangan");

                entity.Property(e => e.TotalTransaksi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Total_Transaksi");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Transaksi_Admin");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Transaksi_Customer");

                entity.HasOne(d => d.IdLapanganNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdLapangan)
                    .HasConstraintName("FK_Transaksi_Lapangan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
