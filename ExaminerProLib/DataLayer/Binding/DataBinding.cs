using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Binding
{
    public class DataBinding
    {
        public static DataTable GetSubjects()
        {
            try
            {
                OleDbCommand oleDbCommand1 = new System.Data.OleDb.OleDbCommand("Select id,subject from  subject", DatabaseController.Instance().Connection);
                OleDbDataReader reader = oleDbCommand1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("subect", typeof(string));
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }

        }

        public static DataTable GetGrades()
        {
            try
            {
                OleDbCommand oleDbCommand1 = new System.Data.OleDb.OleDbCommand("Select number,description from  grades", DatabaseController.Instance().Connection);
                OleDbDataReader reader = oleDbCommand1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("number", typeof(int));
                dt.Columns.Add("description", typeof(string));
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }

        }


        public static DataTable GetQuestionTypes()
        {
            try
            {
                OleDbCommand oleDbCommand1 = new System.Data.OleDb.OleDbCommand("Select number,type from  questiontype", DatabaseController.Instance().Connection);
                OleDbDataReader reader = oleDbCommand1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("number", typeof(int));
                dt.Columns.Add("type", typeof(string));
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }

        }

        public static DataTable GetQuestionNumbers()
        {
            try
            {
                OleDbCommand oleDbCommand1 = new System.Data.OleDb.OleDbCommand("Select number,question from  numberofquestions", DatabaseController.Instance().Connection);
                OleDbDataReader reader = oleDbCommand1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("number", typeof(int));
                dt.Columns.Add("question", typeof(string));
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }
        }

        public static DataTable GetQuestionProfiles()
        {
            try
            {
                OleDbCommand oleDbCommand1 = new System.Data.OleDb.OleDbCommand("Select id,name from  questionprofile", DatabaseController.Instance().Connection);
                OleDbDataReader reader = oleDbCommand1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }
        }
    }
}
