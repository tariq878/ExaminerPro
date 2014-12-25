using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro.Examiner.GUI.Exams.AddWizard
{
    public class Question
    {
        List<QuestionOption> _options = new List<QuestionOption>();
        QuestionData _data = new QuestionData();
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



        public QuestionData Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

    }
}
