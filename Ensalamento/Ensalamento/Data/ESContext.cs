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

        public virtual DbSet<Auth> Auths { get; set; }
        public virtual DbSet<Center> Centers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassReservation> ClassReservations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DeskType> DeskTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectHistory> SubjectHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.HasKey(e => e.UserRegistration)
                    .HasName("PRIMARY");

                entity.Property(e => e.UserRegistration).ValueGeneratedNever();

                entity.HasOne(d => d.UserRegistrationNavigation)
                    .WithOne(p => p.Auth)
                    .HasForeignKey<Auth>(d => d.UserRegistration)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_auth_user_registration");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_department_id");

                entity.HasOne(d => d.DeskType)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.DeskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_desk_type_id");
            });

            modelBuilder.Entity<ClassReservation>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassReservations)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_reservation_class_id");

                entity.HasOne(d => d.Requester)
                    .WithMany(p => p.ClassReservations)
                    .HasForeignKey(d => d.RequesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_reservation_requester_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ClassReservations)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_reservation_subject_id");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("fk_department_center_id");
            });

            modelBuilder.Entity<SubjectHistory>(entity =>
            {
                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subject_history_student_id");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subject_history_subject_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subject_history_teacher_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Registration)
                    .HasName("PRIMARY");

                entity.Property(e => e.Registration).ValueGeneratedNever();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_department_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_role_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
