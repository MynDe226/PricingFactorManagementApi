using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PricingFactorManagementApi.DbSet
{
    public partial class PricingDbContext : DbContext
    {
        public PricingDbContext()
        {
        }

        public PricingDbContext(DbContextOptions<PricingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CountryCode> CountryCodes { get; set; } = null!;
        public virtual DbSet<PricingFactor> PricingFactors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PricingDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryCode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(2);
            });

            modelBuilder.Entity<PricingFactor>(entity =>
            {
                entity.Property(e => e.CountryCode).HasMaxLength(2);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ProductGroup).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
