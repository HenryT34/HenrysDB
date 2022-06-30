using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Henrys_DB
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public DateTime TimeCourseBeginning { get; set; }
        public DateTime TimeCourseEnd { get; set; }
        public DateTime DateDay { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
  