using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro.Examiner.GUI.Exams.AddWizard
{
    public class QuestionOption
    {
        Boolean _correct = false;
        String _text = "";

        public Boolean Correct
        {
            get
            {
                return _correct;
            }
            set
            {
                _correct = value;
            }
        }

        public String DisplayText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
    }
}
