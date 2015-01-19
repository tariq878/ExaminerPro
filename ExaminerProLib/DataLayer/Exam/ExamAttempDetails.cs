using ExaminerProLib.DataLayer.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Exam
{
    public class ExamAttempDetails
    {
        public int ID { get; set; }
        public int AttempId { get; set; }
        public int QuestionId { get; set; }
        public QuestionStatus Status { get; set; }


    }
}
