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

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RIUCCU9;Database=SMS;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname")
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
