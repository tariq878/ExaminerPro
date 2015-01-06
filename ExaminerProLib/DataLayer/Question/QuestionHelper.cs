using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Question
{
    public class QuestionHelper
    {


        public static bool QuestionExists(ref QuestionProfile  _profile)
        {
            try
            {
                String query = "select * from   questionprofile where name = \'" + _profile.ProfileName + "\'";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "questionprofile");

                if (myDataSet.Tables["questionprofile"].Rows.Count < 1)
                {
                    
                    return false;
                }
                else
                {
                    _profile.ID = (int)myDataSet.Tables["questionprofile"].Rows[0]["id"];
                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }

        }

        public static bool SaveQuestion(ref QuestionProfile _profile)
        {
            try
            {
                //1. Create question profile & get the ID.
                //2. Create quesiton with type.
                //3. Save question options.
                String query1 = "Insert into questionprofile (name) values (@name);";
                OleDbCommand myAccessCommand = new OleDbCommand(query1, DatabaseController.Instance().Connection);
                myAccessCommand.Parameters.AddWithValue("@name", _profile.ProfileName);

                myAccessCommand.ExecuteNonQuery();

                //Get the id.
                using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                {
                    cmdNewID.ExecuteNonQuery();

                    _profile.ID = (int)cmdNewID.ExecuteScalar();
                }

                //Lets save each question in the profile.
                foreach (Question question in _profile.Questions)
                {
                    //1 Save the question details.
                    String query2 = "Insert into question (profileid,type,options) values (@pid,@type,opt);";

                    OleDbCommand myAccessCommand1 = new OleDbCommand(query2, DatabaseController.Instance().Connection);
                    myAccessCommand1.Parameters.AddWithValue("@pid", _profile.ID);
                    myAccessCommand1.Parameters.AddWithValue("@type", question.Type);
                    myAccessCommand1.Parameters.AddWithValue("@opt", question.NumOptions);

                    myAccessCommand1.ExecuteNonQuery();
                    //Get the id.
                    using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                    {
                        cmdNewID.ExecuteNonQuery();
                        question.ID = (int)cmdNewID.ExecuteScalar();
                    }


                    int idx = 0;
                    //Insert all options.
                    foreach (QuestionOption option in question.Questions)
                    {
                        //1 Save the question details.
                        String query3 = "Insert into questionoptions (questionid,optionindex,iscorrect,displaytext) values (@qid,@ind,@iscorrect,@dis);";

                        OleDbCommand myAccessCommand2 = new OleDbCommand(query3, DatabaseController.Instance().Connection);
                        myAccessCommand2.Parameters.AddWithValue("@qid", question.ID);
                        myAccessCommand2.Parameters.AddWithValue("@ind", idx++);
                        myAccessCommand2.Parameters.AddWithValue("@iscorrect", (option.Correct?"Y":"N"));
                        myAccessCommand2.Parameters.AddWithValue("@dis", option.DisplayText);

                        myAccessCommand2.ExecuteNonQuery();
                        //Get the id.
                        //using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                        //{
                        ///    cmdNewID.ExecuteNonQuery();
                        ///    option.ID = (int)cmdNewID.ExecuteScalar();
                        //}

                    }

                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return true;
            }
            return true;
        }

    
         public static List<QuestionProfile> GetAllQuestions()
        {
            List<QuestionProfile> questions = new List<QuestionProfile>();
            try
            {
                String query = "select * from   questionprofile;";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "questionprofile");

                if (myDataSet.Tables["questionprofile"].Rows.Count < 1)
                {
                    return questions;
                }
                else
                {
                    for (int i = 0; i < myDataSet.Tables["questionprofile"].Rows.Count; i++)
                    {
                        QuestionProfile profile = new QuestionProfile();
                        profile.ID = (int)myDataSet.Tables["questionprofile"].Rows[i]["id"];
                        profile.ProfileName = (string)myDataSet.Tables["questionprofile"].Rows[i]["Name"];
                        profile.Questions = GetProfileQuestions(profile);
                        questions.Add(profile);

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

         private static List<Question> GetProfileQuestions(QuestionProfile profile)
         {
             List<Question> questions = new List<Question>();
             try
             {
                 String query = "select * from   question where profileid = " + profile.ID + ";";
                 OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                 OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                 DataSet myDataSet = new DataSet();
                 myDataAdapter.Fill(myDataSet, "question");

                 if (myDataSet.Tables["question"].Rows.Count < 1)
                 {
                     return questions;
                 }
                 else
                 {
                     for (int i = 0; i < myDataSet.Tables["question"].Rows.Count; i++)
                     {
                         Question question = new Question();
                         question.NumOptions = (int)myDataSet.Tables["question"].Rows[i]["option"];
                         question.ID = (int)myDataSet.Tables["question"].Rows[i]["id"];
                         question.Type = (QuestionType)myDataSet.Tables["question"].Rows[i]["type"];
                         question.Questions = GetQuestionOptions(question);
                         questions.Add(question);

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

         private static List<QuestionOption> GetQuestionOptions(Question question)
         {
             List<QuestionOption> questions = new List<QuestionOption>();
             try
             {
                 String query = "select * from   questionoptions where questionid = " + question.ID + ";";
                 OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                 OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                 DataSet myDataSet = new DataSet();
                 myDataAdapter.Fill(myDataSet, "questionoptions");

                 if (myDataSet.Tables["questionoptions"].Rows.Count < 1)
                 {
                     return questions;
                 }
                 else
                 {
                     for (int i = 0; i < myDataSet.Tables["questionoptions"].Rows.Count; i++)
                     {
                         QuestionOption option = new QuestionOption();
                         option.Correct = ((String)myDataSet.Tables["questionoptions"].Rows[i]["iscorrect"]=="Y" ?true:false);
                         option.DisplayText = (String)myDataSet.Tables["questionoptions"].Rows[i]["displaytext"];
                         option.Index = (int)myDataSet.Tables["questionoptions"].Rows[i]["optionindex"];
                         questions.Add(option);

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


        public static void DeleteQuestion(QuestionProfile _profile)
        {
            try
            {
                //Step 1. delete all question options.
                //Step 2. delete all questions.
                //Step 3. delete question profile.

                String query1 = "delete from questionoptions where questionid = (select id from question where profileid = " + _profile.ID + ")";
                String query2 = "delete from question where profileid = " + _profile.ID + "";
                String query3 = "delete from questionprofile where id = " + _profile.ID + "";

                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
                myDataAdapter.DeleteCommand = DatabaseController.Instance().Connection.CreateCommand();
                myDataAdapter.DeleteCommand.CommandText = query1;
                myDataAdapter.DeleteCommand.ExecuteNonQuery();

                OleDbDataAdapter myDataAdapter1 = new OleDbDataAdapter();
                myDataAdapter1.DeleteCommand = DatabaseController.Instance().Connection.CreateCommand();
                myDataAdapter1.DeleteCommand.CommandText = query2;
                myDataAdapter1.DeleteCommand.ExecuteNonQuery();

                OleDbDataAdapter myDataAdapter2 = new OleDbDataAdapter();
                myDataAdapter2.DeleteCommand = DatabaseController.Instance().Connection.CreateCommand();
                myDataAdapter2.DeleteCommand.CommandText = query3;
                myDataAdapter2.DeleteCommand.ExecuteNonQuery();

                Log.Instance.CreateEntry("Question profile deleted successfully !!");
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return ;
            }
           
        }
    }
}
