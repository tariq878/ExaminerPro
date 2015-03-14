using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Student
{
    public class StudentHelper
    {

        public static bool StudentExists(ref StudentO student)
        {
            try
            {
                String query = "select * from   student where regnum = " + student.RegNumber + ";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "student");

                if (myDataSet.Tables["student"].Rows.Count < 1)
                {
                    return false;
                }
                else
                {
                    student.Id = (int)myDataSet.Tables["student"].Rows[0]["id"];
                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }

        }

        public static bool SaveStudent(ref StudentO student)
        {
            try
            {
                //1. Create question profile & get the ID.
                //2. Create quesiton with type.
                //3. Save question options.
                String query1 = "Insert into student (StudentName,regnum,grade) values (@name,@regnum,@grade);";
                OleDbCommand myAccessCommand = new OleDbCommand(query1, DatabaseController.Instance().Connection);
                myAccessCommand.Parameters.AddWithValue("@name", student.Name);
                myAccessCommand.Parameters.AddWithValue("@grade", student.GradeId);
                myAccessCommand.Parameters.AddWithValue("@regnum", student.RegNumber);

                myAccessCommand.ExecuteNonQuery();

                //Get the id.
                using (OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", DatabaseController.Instance().Connection))
                {
                    cmdNewID.ExecuteNonQuery();

                    student.Id = (int)cmdNewID.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }
            return true;
        }


        public static List<StudentO> GetAllStudents()
        {
            List<StudentO> students = new List<StudentO>();
            try
            {
                String query = "select * from   Student;";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "student");

                if (myDataSet.Tables["student"].Rows.Count < 1)
                {
                    return students;
                }
                else
                {
                    for (int i = 0; i < myDataSet.Tables["student"].Rows.Count; i++)
                    {
                        StudentO student = new StudentO();
                        student.Id = (int)myDataSet.Tables["student"].Rows[i]["id"];
                        student.Name = (String)myDataSet.Tables["student"].Rows[i]["studentname"];
                        student.GradeId = (int)myDataSet.Tables["student"].Rows[i]["grade"];
                        student.RegNumber = (int)myDataSet.Tables["student"].Rows[i]["regnum"];

                        students.Add(student);

                    }
                }

                return students;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }


        }

        public static bool DeleteStudent(StudentO student)
        {
            bool result = false;
            try
            {
                String query1 = "delete from student where id = " + student.Id + "";

                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
                myDataAdapter.DeleteCommand = DatabaseController.Instance().Connection.CreateCommand();
                myDataAdapter.DeleteCommand.CommandText = query1;
                myDataAdapter.DeleteCommand.ExecuteNonQuery();

                Log.Instance.CreateEntry("Student deleted successfully !!");
                result = true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                result = false;
            }

            return result;
        }


        internal static List<StudentO> GetStudentsInGrade(int p)
        {
            List<StudentO> students = new List<StudentO>();
            try
            {
                String query = "select * from   Student where grade = " + p + ";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "student");

                if (myDataSet.Tables["student"].Rows.Count < 1)
                {
                    return students;
                }
                else
                {
                    for (int i = 0; i < myDataSet.Tables["student"].Rows.Count; i++)
                    {
                        StudentO student = new StudentO();
                        student.Id = (int)myDataSet.Tables["student"].Rows[i]["id"];
                        student.Name = (String)myDataSet.Tables["student"].Rows[i]["studentname"];
                        student.GradeId = (int)myDataSet.Tables["student"].Rows[i]["grade"];
                        student.RegNumber = (int)myDataSet.Tables["student"].Rows[i]["regnum"];

                        students.Add(student);

                    }
                }

                return students;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }

        }

        public static string GetStudentName(int p)
        {
            
            try
            {
                String query = "select * from   student where id = " + p + ";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "student");

                if (myDataSet.Tables["student"].Rows.Count < 1)
                {

                    return "";
                }
                else
                {
                    String subject = (String)myDataSet.Tables["studentname"].Rows[0]["description"];
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
