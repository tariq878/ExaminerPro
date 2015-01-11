using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Subject
{
    public class SubjectHelper
    {
        public static String SubjectGetName(int subjectid)
        {
            try
            {
                String query = "select * from   subject where id = " + subjectid+ ";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "subject");

                if (myDataSet.Tables["subject"].Rows.Count < 1)
                {

                    return "";
                }
                else
                {
                    String subject = (String)myDataSet.Tables["subject"].Rows[0]["subject"];
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
