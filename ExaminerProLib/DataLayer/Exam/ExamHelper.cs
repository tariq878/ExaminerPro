using ExaminerProLib.DataLayer.Student;
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

        #region ExamAssign

        public static List<ExamAssignO> GetAllExamAssignO()
        {
            List<ExamAssignO> questions = new List<ExamAssignO>();
            try
            {
                String query = "select * from   Examassign;";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "Examassign");

                if (myDataSet.Tables["Examassign"].Rows.Count < 1)
                {
                    return questions;
                }
                else
                {
                    for (int i = 0; i < myDataSet.Tables["Examassign"].Rows.Count; i++)
                    {
                        ExamAssignO exam = new ExamAssignO();
                        exam.Id = (int)myDataSet.Tables["Examassign"].Rows[i]["id"];
                        exam.UserId = (int)myDataSet.Tables["Examassign"].Rows[i]["userid"];
                        String temp  = (String) myDataSet.Tables["Examassign"].Rows[i]["tograde"];
                        exam.IsToGrade = (temp == "True" ? true : false);
                        exam.GradeId = (int)myDataSet.Tables["Examassign"].Rows[i]["gradeid"];
                        exam.StudentId = (int)myDataSet.Tables["Examassign"].Rows[i]["studentid"];
                        exam.StudentCount = (int)myDataSet.Tables["Examassign"].Rows[i]["studentsimpacted"];
                        exam.ExamId = (int)myDataSet.Tables["Examassign"].Rows[i]["examid"];

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


        public static bool AssignExamInsert(ref ExamAssignO assign)
        {
            bool result = false;

            try
            {
                if (assign.IsToGrade)
                {
                    //Get all the students in a grade.
                    List<StudentO> students = StudentHelper.GetStudentsInGrade(assign.GradeId);

                    assign.StudentCount = students.Count;
                    //We need to insert the assignment records for each user.
                    result = AssignExamInsertByGrade(ref  assign);

                    foreach (StudentO stud in students)
                    {
                        //Insert record for one student.
                        ExamAssignment assignment = new ExamAssignment();
                        assignment.StudentId = stud.Id;
                        assignment.ExamId = assign.ExamId;
                        assignment.AssignmentId = assign.Id;
                        AssignmentExamInsert(ref assignment);

                    }
                    
                }
                else
                {
                   result = AssignExamInsertByStudent(ref  assign);
                    //Insert record for one student.
                    ExamAssignment assignment = new ExamAssignment();
                    assignment.StudentId = assign.StudentId;
                    assignment.ExamId = assign.ExamId;
                    assignment.AssignmentId = assign.Id;
                    AssignmentExamInsert(ref assignment);

                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                result = false;
            }

            return result;
        }

        private static bool AssignExamInsertByStudent(ref ExamAssignO assign)
        {
            bool result = false;

            try
            {

                String query1 = "Insert into examassign (examid,userid,tograde,studentid,dateassigned,studentsimpacted) " +
                    " values (@examid,@userid,@tograde,@studentid,@dateassigned,@studentsimpacted);";
                OleDbCommand myAccessCommand = new OleDbCommand(query1, DatabaseController.Instance().Connection);
                myAccessCommand.Parameters.AddWithValue("@examid", assign.ExamId);
                myAccessCommand.Parameters.AddWithValue("@userid", assign.UserId);
                myAccessCommand.Parameters.AddWithValue("@tograde", assign.IsToGrade);
                myAccessCommand.Parameters.AddWithValue("@studentid", assign.StudentId);
                myAccessCommand.Parameters.AddWithValue("@dateassigned", assign.AssignDate);
                myAccessCommand.Parameters.AddWithValue("@studentsimpacted", 1);
                myAccessCommand.Parameters.AddWithValue("@dateassigned", assign.AssignDate);

                myAccessCommand.ExecuteNonQuery();

                //Get the id.
                using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                {
                    cmdNewID.ExecuteNonQuery();

                    assign.Id = (int)cmdNewID.ExecuteScalar();
                }
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                result = false;
            }

            return result;  
        }

        private static bool AssignExamInsertByGrade(ref ExamAssignO assign)
        {
            bool result = false;

            try
            {

                String query1 = "Insert into examassign (examid,userid,tograde,gradeid,studentsimpacted) " +
                    " values (@examid,@userid,@tograde,@gradeid,@studentsimpacted);";

                OleDbCommand myAccessCommand = new OleDbCommand(query1, DatabaseController.Instance().Connection);
                myAccessCommand.Parameters.AddWithValue("@examid", assign.ExamId);
                myAccessCommand.Parameters.AddWithValue("@userid", assign.UserId);
                myAccessCommand.Parameters.AddWithValue("@tograde", assign.IsToGrade.ToString());
                myAccessCommand.Parameters.AddWithValue("@gradeid", assign.GradeId);
                //myAccessCommand.Parameters.AddWithValue("@dateassigned",DateTime.Now.Date);
                myAccessCommand.Parameters.AddWithValue("@studentsimpacted", assign.StudentCount);

                myAccessCommand.ExecuteNonQuery();

                //Get the id.
                using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                {
                    cmdNewID.ExecuteNonQuery();

                    assign.Id = (int)cmdNewID.ExecuteScalar();
                }
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                result = false;
            }

            return result; 
        }

        private static object GetDateWithoutMilliseconds(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }


        #endregion

        #region Assignment
        //Insert one assignment record.
        public static bool AssignmentExamInsert(ref ExamAssignment  assignment)
        {
            bool result = false;
          
            try
            {
                
                String query1 = "Insert into examassigned (examid,assignmentid,studentid) values (@examid,@assignmentid,@studentid);";
                OleDbCommand myAccessCommand = new OleDbCommand(query1, DatabaseController.Instance().Connection);
                myAccessCommand.Parameters.AddWithValue("@examid", assignment.ExamId);
                myAccessCommand.Parameters.AddWithValue("@assignmentid", assignment.AssignmentId);
                myAccessCommand.Parameters.AddWithValue("@studentid", assignment.StudentId);

                myAccessCommand.ExecuteNonQuery();

                //Get the id.
                using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                {
                    cmdNewID.ExecuteNonQuery();

                    assignment.Id = (int)cmdNewID.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                result = false;
            }

            return result;
        }


        //Insert one assignment record.
        public static bool AssignmentExamDelete(ref ExamAssignment assignment)
        {
            bool result = false;

            try
            {

                String query1 = "delete from examassignment where id = " + assignment.Id + "";

                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
                myDataAdapter.DeleteCommand = DatabaseController.Instance().Connection.CreateCommand();
                myDataAdapter.DeleteCommand.CommandText = query1;
                myDataAdapter.DeleteCommand.ExecuteNonQuery();

                Log.Instance.CreateEntry("Exam Assignment deleted successfully !!");
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                result = false;
            }

            return result;
        }
        #endregion 

    
       
    
        public static string GetExamName(int p)
        {
            try
            {
                String query = "select * from   exam where id= " + p + ";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "exam");

                if (myDataSet.Tables["exam"].Rows.Count < 1)
                {

                    return "";
                }
                else
                {
                    String subject = (String)myDataSet.Tables["exam"].Rows[0]["title"];
                    return subject;
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return "";
            }
        }
    }
}
