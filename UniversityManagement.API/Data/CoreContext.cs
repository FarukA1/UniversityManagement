using System;
using System.Collections.Generic;
using UniversityManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityManagement.API
{
	public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the composite primary key for CourseAssignment
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(ca => new { ca.CourseId, ca.InstructorId });

            // Configure the relationship between Course and CourseAssignment
            modelBuilder.Entity<CourseAssignment>()
                .HasOne(ca => ca.Course)
                .WithMany(c => c.CourseAssignments)
                .HasForeignKey(ca => ca.CourseId);

            // Configure the relationship between Instructor and CourseAssignment
            modelBuilder.Entity<CourseAssignment>()
                .HasOne(ca => ca.Instructor)
                .WithMany(i => i.CourseAssignments)
                .HasForeignKey(ca => ca.InstructorId);

            // Configure the relationship between Course and Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Configure the relationship between Student and Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            // Configure the relationship between Department and Course
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Courses)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DepartmentId);

            // Configure the relationship between Department and Instructor (Administrator)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Administrator)
                .WithMany(i => i.AdministratedDepartments)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure the relationship between ClassSchedule and Course
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.ClassSchedules)
                .HasForeignKey(cs => cs.CourseId);

            // Configure the relationship between ClassSchedule and Classroom
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Classroom)
                .WithMany(cr => cr.ClassSchedules)
                .HasForeignKey(cs => cs.ClassroomId);

            // Configure the relationship between ClassSchedule and Instructor
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Instructor)
                .WithMany(i => i.ClassSchedules)
                .HasForeignKey(cs => cs.InstructorId);

            // Configure optional properties for collections
            modelBuilder.Entity<Classroom>()
                .HasMany(cr => cr.ClassSchedules)
                .WithOne(cs => cs.Classroom)
                .IsRequired(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .IsRequired(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseAssignments)
                .WithOne(ca => ca.Course)
                .IsRequired(false);

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.CourseAssignments)
                .WithOne(ca => ca.Instructor)
                .IsRequired(false);

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.ClassSchedules)
                .WithOne(cs => cs.Instructor)
                .IsRequired(false);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .IsRequired(false);
        }
    }
}

