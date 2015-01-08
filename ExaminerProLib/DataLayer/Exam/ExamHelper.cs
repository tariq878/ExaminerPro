using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Exam
{
    public class ExamHelper
    {


        public static bool ExamExists(ref Exam exam)
        {
            try
            {
                String query = "select * from   exam where title = \'" + exam.Name + "\'";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "exam");

                if (myDataSet.Tables["exam"].Rows.Count < 1)
                {

                    return false;
                }
                else
                {
                    exam.Id = (int)myDataSet.Tables["exam"].Rows[0]["id"];
                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }

        }

        public static bool SaveExam(ref Exam exam)
        {
            try
            {
                //1. Create question profile & get the ID.
                //2. Create quesiton with type.
                //3. Save question options.
                String query1 = "Insert into exam (title,gradeid,subjectid,questionid) values (@name,@grade,@subject,@question);";
                OleDbCommand myAccessCommand = new OleDbCommand(query1, DatabaseController.Instance().Connection);
                myAccessCommand.Parameters.AddWithValue("@name", exam.Name);
                myAccessCommand.Parameters.AddWithValue("@grade", exam.GradeId);
                myAccessCommand.Parameters.AddWithValue("@subject", exam.SubjectId);
                myAccessCommand.Parameters.AddWithValue("@question", exam.QuestionId);

                myAccessCommand.ExecuteNonQuery();

                //Get the id.
                using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                {
                    cmdNewID.ExecuteNonQuery();

                    exam.Id = (int)cmdNewID.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }
            return true;
        }


        public static List<Exam> GetAllExams()
        {
            List<Exam> questions = new List<Exam>();
            try
            {
                String query = "select * from   Exam;";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "exam");

                if (myDataSet.Tables["exam"].Rows.Count < 1)
                {
                    return questions;
                }
                else
                {
                    for (int i = 0; i < myDataSet.Tables["exam"].Rows.Count; i++)
                    {
                        Exam exam = new Exam();
                        exam.Id = (int)myDataSet.Tables["exam"].Rows[i]["id"];
                        exam.Name = (String)myDataSet.Tables["exam"].Rows[i]["title"];
                        exam.GradeId = (int)myDataSet.Tables["exam"].Rows[i]["gradeid"];
                        exam.SubjectId = (int)myDataSet.Tables["exam"].Rows[i]["subjectid"];
                        exam.QuestionId = (int)myDataSet.Tables["exam"].Rows[i]["questionid"];

                        questions.Add(exam);

                    }
                }

                return questions;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }


        }

        public static bool DeleteExam(Exam exam)
        {
            bool result = false;
            try
            {
                String query1 = "delete from exam where id = " + exam.Id + "";

                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
                myDataAdapter.DeleteCommand = DatabaseController.Instance().Connection.CreateCommand();
                myDataAdapter.DeleteCommand.CommandText = query1;
                myDataAdapter.DeleteCommand.ExecuteNonQuery();

                Log.Instance.CreateEntry("Exam deleted successfully !!");
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                result = false;
            }

            return result;
        }

    }
}
