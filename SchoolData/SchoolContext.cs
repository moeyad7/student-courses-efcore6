using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolDomain;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace SchoolData
{

    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public SchoolContext() { }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                // optionsBuilder.UseNpgsql("User ID =postgres;Password=f3VkwpH8h7SCHTY8SaMT;Server=gb-core-staging.cmzirgtmsmqt.us-west-2.rds.amazonaws.com;Port=5432;Database=gameball-mohamed;Pooling=true;Timeout=15;SSL Mode=Disable;"
                // ).LogTo(Console.WriteLine,
                //         new[] { DbLoggerCategory.Database.Command.Name },
                //         LogLevel.Information).EnableSensitiveDataLogging();

                optionsBuilder.UseNpgsql("User ID =postgres;Password=mhmh2621ea;Server=myserver,localhost;Port=5432;Database=SchoolContext;Pooling=true;Timeout=15;SSL Mode=Disable;"
                ).LogTo(Console.WriteLine,
                        new[] { DbLoggerCategory.Database.Command.Name },
                        LogLevel.Information).EnableSensitiveDataLogging();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
            .HasKey(e => e.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne<Student>(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne<Course>(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);


            var coursesList = new Course[]{
                new Course { CourseId = 1, Title = "Mathematics", Description = "Introduction to Mathematics" },
                new Course { CourseId = 2, Title = "Science", Description = "Introduction to Science" },
                new Course { CourseId = 3, Title = "History", Description = "Introduction to History" }
            };

            modelBuilder.Entity<Course>().HasData(coursesList);

            var studentsList = new Student[]{
                new Student { StudentId = 1, Name = "John Doe", Age = 18, GPA = 3.8 },
                new Student { StudentId = 2, Name = "Jane Smith", Age = 19, GPA = 3.9 },
                new Student { StudentId = 3, Name = "Alice Johnson", Age = 20, GPA = 3.5 },
                new Student { StudentId = 4, Name = "Bob Brown", Age = 21, GPA = 3.7 }
            };
            modelBuilder.Entity<Student>().HasData(studentsList);


            var enrollmentsList = new Enrollment[]{
                new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.UtcNow },
                new Enrollment { EnrollmentId = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.UtcNow },
                new Enrollment { EnrollmentId = 3, StudentId = 3, CourseId = 1, EnrollmentDate = DateTime.UtcNow },
                new Enrollment { EnrollmentId = 4, StudentId = 4, CourseId = 3, EnrollmentDate = DateTime.UtcNow },
                new Enrollment { EnrollmentId = 5, StudentId = 4, CourseId = 2, EnrollmentDate = DateTime.UtcNow }
            };
            modelBuilder.Entity<Enrollment>().HasData(enrollmentsList);
        }
    }

}
