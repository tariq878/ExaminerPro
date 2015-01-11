using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Grade
{
    public class GradeHelper
    {
        public static String GetGradeName(int gradeid)
        {
            try
            {
                String query = "select * from   grades where number = " + gradeid + ";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "grades");

                if (myDataSet.Tables["grades"].Rows.Count < 1)
                {

                    return "";
                }
                else
                {
                    String subject = (String)myDataSet.Tables["grades"].Rows[0]["description"];
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
