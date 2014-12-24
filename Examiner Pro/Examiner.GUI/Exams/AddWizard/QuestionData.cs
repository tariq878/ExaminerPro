using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro.Examiner.GUI.Exams.AddWizard
{

    public enum QuestionType { MCQ, Multiple, TF};

    public class QuestionData
    {
        int _id = 0;
        QuestionType _type;
        int _numoptions;

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

        public int QuestionCount
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
    }
}
