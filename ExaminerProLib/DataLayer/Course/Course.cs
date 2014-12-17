using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro.DataLayer
{
    public class Course
    {
        public Course()
        {
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Questions { get; set; }
        public int Duration { get; set; }
    }
}
