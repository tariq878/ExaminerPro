using ExaminerProLib.DataLayer.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Exam
{
    public class ExamAttempt
    {
        int ID { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        QuestionStatus Status { get; set; }
        int StudentId { get; set; }
        int GradeId { get; set; }
        int ExamId { get; set; }
        int QuestionCount { get; set; }
        
    }
}
