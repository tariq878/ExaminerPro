﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Exam
{
    public class Exam
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
        public int QuestionId { get; set; }
    
    }
}
