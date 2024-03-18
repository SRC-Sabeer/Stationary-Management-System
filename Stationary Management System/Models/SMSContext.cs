using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Stationary_Management_System.Models
{
    public partial class SMSContext : DbContext
    {
        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Application)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("application");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Function)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("function");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PackageWeight).HasColumnName("package_weight");

                entity.Property(e => e.PlaceOfOrigin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("place_of_origin");

                entity.Property(e => e.Price1).HasColumnName("price1");

                entity.Property(e => e.Price2).HasColumnName("price2");

                entity.Property(e => e.Price3).HasColumnName("price3");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.Property(e => e.Warranty)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("warranty");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
