using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Henrys_DB
{
    public class HenrysDBContext : DbContext
    {
        public HenrysDBContext(DbContextOptions<HenrysDBContext> options)
            : base(options)
        {

        } 

        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourseMapping> StudentCourseMappings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tutor>(e =>
            {
                //e.HasKey(p => new { p.Id, p.LastName });
                e.HasKey(p => p.Id);
                e.Property(p => p.LastName).HasMaxLength(50);
                e.Property(p => p.DateCreated).HasDefaultValueSql("GETDATE()");
                e.Property(p => p.DateModified).HasDefaultValueSql("GETDATE()");

                e.ToTable("Tutor", "dbo");
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.FirstName);
                e.Property(p => p.LastName);
                e.Property(p => p.Age);
                e.Property(p => p.DateCreated).HasDefaultValueSql("GETDATE()");
                e.Property(p => p.DateModified).HasDefaultValueSql("GETDATE()");

                e.ToTable("Student", "dbo");
            });

            modelBuilder.Entity<StudentCourseMapping>(e =>
            {
                e.HasKey(p => new { p.StudentId, p.CourseId });
                e.Property(p => p.DateCreated).HasDefaultValueSql("GETDATE()");
                e.Property(p => p.DateModified).HasDefaultValueSql("GETDATE()");

                e.ToTable("StudentCourseMapping", "dbo");
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.DisplayName);
                e.Property(p => p.RoomId);
                e.Property(p => p.ScheduleId);
                e.Property(p => p.TutorId);
                e.Property(p => p.Price);
                e.Property(p => p.DateCreated).HasDefaultValueSql("GETDATE()");
                e.Property(p => p.DateModified).HasDefaultValueSql("GETDATE()");

                e.ToTable("Course", "dbo");
            });

            modelBuilder.Entity<Room>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.RoomName);
                e.Property(p => p.DateCreated).HasDefaultValueSql("GETDATE()");
                e.Property(p => p.DateModified).HasDefaultValueSql("GETDATE()");

                e.ToTable("Room", "dbo");
            });

            modelBuilder.Entity<Schedule>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.TimeCourseBeginning);
                e.Property(p => p.TimeCourseEnd);
                e.Property(p => p.DateDay);
                e.Property(p => p.DateCreated).HasDefaultValueSql("GETDATE()");
                e.Property(p => p.DateModified).HasDefaultValueSql("GETDATE()");

                e.ToTable("Schedule", "dbo");
            });
        }
    }
}
