using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Henrys_DB
{
    public partial class StudentCourseMapping
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
