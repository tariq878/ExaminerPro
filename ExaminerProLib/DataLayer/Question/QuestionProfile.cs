using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExaminerProLib.DataLayer.Question
{
    [XmlRoot("QuestionProfile")]
    public class QuestionProfile
    {

        private int _id;
        private String _profilename;
        private List<QuestionInfo> _questions = new List<QuestionInfo>();

        [XmlElement("ID")]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlElement("ProfileName")]
        public String ProfileName
        {
            get { return _profilename; }
            set { _profilename = value; }
        }

        [XmlElement("Details")]
        public List<QuestionInfo> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
    }
}
