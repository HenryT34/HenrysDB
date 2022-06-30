using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Henrys_DB
{
    public partial class Course
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int RoomId { get; set; }
        public int ScheduleId { get; set; }
        public int TutorId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
