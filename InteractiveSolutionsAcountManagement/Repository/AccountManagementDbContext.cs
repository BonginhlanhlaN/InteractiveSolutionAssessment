using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InteractiveSolutionsAcountManagement.Repository.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InteractiveSolutionsAcountManagement.Repository
{
    public partial class AccountManagementDbContext : DbContext
    {
        /*
        public AccountManagementDbContext()
        {
        }
        */

        public AccountManagementDbContext(DbContextOptions<AccountManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AccountManagement_db;Integrated Security=True");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasIndex(e => e.AccountNumber)
                    .HasName("IX_Account_num")
                    .IsUnique();

                entity.Property(e => e.AccountNumber).IsUnicode(false);

                entity.HasOne(d => d.PersonCodeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PersonCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Person");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasIndex(e => e.IdNumber)
                    .HasName("IX_Person_id")
                    .IsUnique();

                entity.Property(e => e.IdNumber).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.AccountCodeNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
