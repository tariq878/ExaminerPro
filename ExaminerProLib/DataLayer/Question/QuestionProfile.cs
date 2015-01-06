using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Question
{
    public class QuestionProfile
    {

        private int _id;
        private String _profilename;
        private List<QuestionInfo> _questions = new List<QuestionInfo>();

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

        public List<QuestionInfo> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
    }
}
