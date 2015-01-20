using ExaminerProLib.DataLayer.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Exam
{
    public enum AttemptStatus { Started, Finished };

    public class ExamAttemptD
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AttemptStatus Status { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public int ExamId { get; set; }
        public int QuestionCount { get; set; }
    }
}
