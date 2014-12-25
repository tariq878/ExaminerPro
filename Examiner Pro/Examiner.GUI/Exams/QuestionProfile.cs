using Examiner_Pro.Examiner.GUI.Exams.AddWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examiner_Pro.Examiner.GUI.Exams
{
    class QuestionProfile
    {
        private int _id;
        private String _profilename;
        private List<Question> _questions = new List<Question>();

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String ProfileName
        {
            get { return _profilename; }
            set { _profilename = value; }
        }

        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
    }
}
