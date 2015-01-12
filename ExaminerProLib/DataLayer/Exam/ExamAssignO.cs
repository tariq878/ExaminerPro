using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Exam
{
    public class ExamAssignO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsToGrade { get; set; }
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public DateTime AssignDate { get; set; }
        public int StudentCount { get; set; }
        public int ExamId { get; set; }
    }
}
