using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer
{
    class DatabaseController
    {
        private String connectionString;
        private String OleDBProvider = "Microsoft.ACE.OLEDB.12.0";
        private String OleDBDataSource = @"R:\01 - Data\01 - Tariq\Develop\C#\Examiner Pro\ExaminerPro\Examiner Pro\DB\Data.accdb";
        private String OleDBPassword = "";
        private String PersistSecurityInfo = "False";

        OleDbConnection _connection;

        private static DatabaseController _instance = null;

        public static DatabaseController Instance()
        {
            if (_instance == null)
                _instance = new DatabaseController();

            return _instance;
        }

        public OleDbConnection Connection 
        { get 
            {
                if (_connection == null)
                {
                    _connection = new OleDbConnection(connectionString);
                }

                if (_connection.State != System.Data.ConnectionState.Open)
                    _connection.Open();

                return _connection; 
        
            } 
        }

        private DatabaseController()
        {

            OleDBDataSource = LocateDatabBase();
 

            connectionString = "Provider=" + OleDBProvider + ";Data Source=" + OleDBDataSource + ";JET OLEDB:Database Password=" + OleDBPassword + ";Persist Security Info=" + PersistSecurityInfo + "";
        }

        private String LocateDatabBase()
        {
            String path = "";
            path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            path = Directory.GetParent(Directory.GetParent(path).FullName).FullName;

            //Find the database file under the directory.
            String[] dirs = Directory.GetFiles(path, "Data.accdb", SearchOption.AllDirectories);

            if (dirs.Length != 1)
            {
                Log.Instance.CreateEntry("Database file could not be found. please check if it exisis");
                return null;
            }

            path = dirs[0];
            return path;
        }

        public bool Connect()
        {
            try
            {
                _connection = new OleDbConnection(connectionString);
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }


            return true;
        }

    }
}
