using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace P01_StudentSystem.Data
{
    class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source =.; Integrated Security = True; Connect Timeout = 30;Initial Catalog=EFStudentSystem" +
                "Encrypt = True; Trust Server Certificate = True;");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(e => { 
                e.HasKey(e => e.StudentId);

                e.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

                e.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

                e.Property(e => e.RegisteredOn).IsRequired();
                e.Property(e => e.Birthday).IsRequired(false);

            });

            modelBuilder.Entity<Course>(e => {
                e.HasKey(e => e.CourseId);

                e.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(true);

                e.Property(e => e.Description)
                .IsUnicode(true)
                .IsRequired(false);
            });

            modelBuilder.Entity<Resource>(e => {
                    e.HasKey(e => e.ResourceId);

                    e.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                    e.Property(e => e.Url).IsUnicode(false);
                });

                modelBuilder.Entity<HomeWork>(e =>
                {
                    e.HasKey(e => e.HomeworkId);

                    e.Property(e => e.Content)
                    .IsUnicode(false);
                });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId }); 

                entity.HasOne(e => e.Student)
                      .WithMany(e => e.StudentCourses)
                      .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                      .WithMany(e => e.StudentCourses)
                      .HasForeignKey(e => e.CourseId);
            });
        }
    }
}