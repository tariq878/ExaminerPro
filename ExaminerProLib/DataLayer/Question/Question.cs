﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Question
{
    public enum QuestionType { MCQ, Multiple, TF };

    public class Question
    {
       
        int _id;
        QuestionType _type;
        int _numoptions;

        List<QuestionOption> _options = new List<QuestionOption>();
       
        public List<QuestionOption> Questions
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
            }
        }

        public int NumOptions
        {
            get
            {
                return _numoptions;
            }
            set
            {
                _numoptions = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }


        public QuestionType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
}