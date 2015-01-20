using ExaminerProLib.DataLayer.Question;
using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Exam
{
    public class ExamAssignmentHelper
    {
        public static bool SaveAttempt(Question.QuestionProfile _profile, ref ExamAttemptD attempt)
        {
            //1. Insert in attempt.
            //2. insert the details.
            try
            {
                //1. Create question profile & get the ID.
                //2. Create quesiton with type.
                //3. Save question options.
                String query1 = "Insert into examattempt (status,studentid,examid,gradeid,numquestions) values (@st,@stid,@eid,@gid,@que);";
                OleDbCommand myAccessCommand = new OleDbCommand(query1, DatabaseController.Instance().Connection);
                myAccessCommand.Parameters.AddWithValue("@st", attempt.Status);
                myAccessCommand.Parameters.AddWithValue("@stid", attempt.StudentId);
                myAccessCommand.Parameters.AddWithValue("@eid", attempt.ExamId);
                myAccessCommand.Parameters.AddWithValue("@gid", attempt.GradeId);
                myAccessCommand.Parameters.AddWithValue("@que", attempt.QuestionCount);

                myAccessCommand.ExecuteNonQuery();

                //Get the id.
                using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                {
                    cmdNewID.ExecuteNonQuery();

                    attempt.ID = (int)cmdNewID.ExecuteScalar();
                }

                //Lets save each question in the profile.
                foreach (QuestionInfo question in _profile.Questions)
                {
                    //1 Save the question details.
                    String query2 = "Insert into examattempdetails (attemptid,questionid,status) values (@aid,@qid,@st);";

                    OleDbCommand myAccessCommand1 = new OleDbCommand(query2, DatabaseController.Instance().Connection);
                    myAccessCommand1.Parameters.AddWithValue("@aid", attempt.ID);
                    myAccessCommand1.Parameters.AddWithValue("@qid", question.ID);
                    myAccessCommand1.Parameters.AddWithValue("@st", question.Correct);
                    myAccessCommand1.ExecuteNonQuery();


                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return true;
            }
            return true;
        }
    }
}
