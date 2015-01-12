using ExaminerProLib.DataLayer.Question;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExaminerProLib.Utils
{
    public class ExportUtils
    {
        public static bool ExportQuestionProfile(QuestionProfile profile)
        {
            bool result = false;

            try
            {
                string filename = profile.ProfileName + DateTime.Now.ToString("MM-DD-YYYY-hhmmsss") + ".xml";
                XmlSerializer serializer = new XmlSerializer(typeof(QuestionProfile));

                using (TextWriter writer = new StreamWriter(filename))
                {
                    serializer.Serialize(writer, profile);
                } 
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }

            return result;
        }

        public static QuestionProfile ImportQuestionProfile(String filename)
        {
            QuestionProfile profile = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(QuestionProfile));
                TextReader reader = new StreamReader(filename);
                object obj = deserializer.Deserialize(reader);
                profile = (QuestionProfile)obj;
            
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }

            return profile;
        }

        public static bool ExportStudents(List<DataLayer.Student.StudentO> _student)
        {
            bool result = false;

            try
            {
                string filename = "Students"+DateTime.Now.ToString("MM-DD-YYYY-hhmmsss") + ".xml";
                XmlSerializer serializer = new XmlSerializer(typeof(List<DataLayer.Student.StudentO>));

                using (TextWriter writer = new StreamWriter(filename))
                {
                    serializer.Serialize(writer, _student);
                }
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }

            return result;
        }

        public static List<DataLayer.Student.StudentO> ImportStudents(string filename)
        {
            List<DataLayer.Student.StudentO> profile = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<DataLayer.Student.StudentO>));
                TextReader reader = new StreamReader(filename);
                object obj = deserializer.Deserialize(reader);
                profile = (List<DataLayer.Student.StudentO>)obj;

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }

            return profile;
        }
    }
}
