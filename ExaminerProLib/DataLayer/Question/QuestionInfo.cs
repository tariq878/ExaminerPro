using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExaminerProLib.DataLayer.Question
{
    public enum QuestionType { MCQ, Multiple, TF };
    public enum QuestionStatus { Correct, Wrong, Skipped , Unknown};

    public class QuestionInfo
    {
       
        int _id;
        QuestionType _type;
        int _numoptions;
        QuestionStatus _correct;

        List<QuestionOption> _options = new List<QuestionOption>();

        public QuestionInfo()
        {
            _correct = QuestionStatus.Unknown;
        }


        [XmlElement("Questions")]
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

         [XmlAttribute("QuestionCount")]
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

         [XmlAttribute("ID")]
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

          [XmlAttribute("Type")]
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

        [XmlIgnore]
          public QuestionStatus Correct
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
          public string QuestionText { get; set; }
    }
}
