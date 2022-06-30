using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Henrys_DB;
using Microsoft.EntityFrameworkCore;

namespace HenrysDbLayer
{
    public class DBLogic
    {
        private HenrysDBContext _context;

        public DBLogic(HenrysDBContext context)
        {
            this._context = context;
        }

        public IEnumerable<Course> GetCourses()
        {
            return  _context.Courses.ToList();
        }

        public IEnumerable<Members> GetCourseMembers(int id)
        {
            return (from members in _context.Students
                   join studentcourses in _context.StudentCourseMappings on members.Id equals studentcourses.StudentId
                   join courses in _context.Courses on studentcourses.CourseId equals courses.Id
                   join tutors in _context.Tutors on courses.TutorId equals tutors.Id
                   where courses.Id == id
                   select new Members() { MemberFirstName = members.FirstName, MemberLastName = members.LastName, TutorsLastName = tutors.LastName, DisplayName = courses.DisplayName })
                   .ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Added;
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetStudentIds()
        {
            return (from members in _context.Students
                    select new Student() { FirstName =  members.FirstName,  LastName = members.LastName, Id = members.Id })
                    .ToList();
        }

        public IEnumerable<CourseDetails> GetCourseDetails()
        {
            return (from courses in _context.Courses
                    join tutors in _context.Tutors on courses.TutorId equals tutors.Id
                    select new CourseDetails() { DisplayName = courses.DisplayName, Price = courses.Price, LastName = tutors.LastName, Id = courses.Id})
                    .ToList();
        }

        public void AddSCMapping(StudentCourseMapping scm)
        {
            _context.Entry(scm).State = EntityState.Added;
            _context.StudentCourseMappings.Add(scm);
            _context.SaveChanges();
        }

        public void AddTutor(Tutor tutor)
        {
            _context.Entry(tutor).State = EntityState.Added;
            _context.Tutors.Add(tutor);
            _context.SaveChanges();
        }

        public void AddScheduleDay(Schedule slot)
        {
            _context.Entry(slot).State = EntityState.Added;          
            _context.Schedules.Add(slot);         
            _context.SaveChanges();
        }

    }
}
