using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestTaskBGL
{
    public partial class test_task_bgldbContext : DbContext
    {
        public test_task_bgldbContext()
        {
        }

        public test_task_bgldbContext(DbContextOptions<test_task_bgldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP;Initial Catalog=test_task_bgldb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(100);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentName).HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Compa__267ABA7A");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.EmpPatronymic).HasMaxLength(100);

                entity.Property(e => e.EmpSurname).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Posit__2C3393D0");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionName).HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Positions__Depar__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
