using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExaminerProLib.DataLayer.Question
{
    public class QuestionOption
    {
        Boolean _correct = false;
        String _text = "";

         [XmlElement("IsTrue")]
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

         [XmlElement("Text")]
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


        public int Index { get; set; }
    }
}
