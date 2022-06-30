using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Henrys_DB;
using HenrysDbLayer;

namespace ConsoleHenrysDB
{
    public class ConsoleFunctions
    {
        public void WriteEmptyLine()
        {
            Console.WriteLine(" ");
        }

        public void GetCourseNames(IEnumerable<Course> courses)
        {
            foreach (var c in courses)
            {
                Console.WriteLine(WriteCourseNames(c));
            }
        }
        public string GetInput()
        {
            var input = Console.ReadLine();
            return input;
        }

        public string WriteCourseNames(Course courses)
        {        
            return $"Kursname: {courses.DisplayName} Id: {courses.Id}";
        }

        public void WriteCourseMembers(Members member)
        {
            Console.WriteLine("FirstName: {0}; LastName: {1}; LehrerName: {2}; DisplayName: {3}", member.MemberFirstName, member.MemberLastName, member.TutorsLastName, member.DisplayName);
        }

        public void WriteCourseMembersOutput(IEnumerable<Members> members)
        {
            foreach (var cm in members)
            {
                WriteCourseMembers(cm);             
            }
        }

        public void GetStudentNames(Student student)
        {
            Console.WriteLine("FirstName: {0}; LastName: {1}; Id: {2}", student.FirstName, student.LastName, student.Id);
        }

        public void WriteStudentIds(IEnumerable<Student> student)
        {
            foreach (var s in student)
            {
                Console.WriteLine("FirstName: {0}; LastName: {1}; Id: {2}", s.FirstName, s.LastName, s.Id);
            }
        } 

        public void WriteCourseDetails(IEnumerable<CourseDetails> courseDetails)
        {
            foreach (var c in courseDetails)
            {
                Console.WriteLine("DisplayName: {0}; Price: {1}; LastName: {2}; Id: {3}", c.DisplayName, c.Price, c.LastName, c.Id);
            }
        }
    }
}
