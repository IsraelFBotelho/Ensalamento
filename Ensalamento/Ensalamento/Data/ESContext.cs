using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ensalamento.Models;

#nullable disable

namespace Ensalamento.Data
{
    public partial class ESContext : DbContext
    {
        public ESContext()
        {
        }

        public ESContext(DbContextOptions<ESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auth> Auth { get; set; }
        public virtual DbSet<Center> Center { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("auth");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("password");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Auth)
                    .HasForeignKey<Auth>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_id");
            });

            modelBuilder.Entity<Center>(entity =>
            {
                entity.ToTable("center");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acronym)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("acronym");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.CenterId, "fk_center_id");

                entity.HasIndex(e => e.Name, "name_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acronym)
                    .HasMaxLength(16)
                    .HasColumnName("acronym");

                entity.Property(e => e.CenterId).HasColumnName("center_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("fk_center_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.Name, "name_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.DepartmentId, "fk_department_id");

                entity.HasIndex(e => e.RoleId, "fk_role_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("last_name");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_department_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_role_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
