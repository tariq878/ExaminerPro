using ExaminerProLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Users
{
    public class UserHelper
    {
        public static bool UserExists(User user)
        {
            try
            {
                User userval = new User();
                String query = "select * from users where username = \'" + user.UserName + "\'";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "users");

                if (myDataSet.Tables["users"].Rows.Count < 1)
                {
                    Log.Instance.CreateEntry("user not found in database " + user.UserName);
                    return false;
                }

                userval.UserName = (String)myDataSet.Tables["users"].Rows[0]["username"];
                userval.ID = (int)myDataSet.Tables["users"].Rows[0]["ID"];
                userval.Password = (String)myDataSet.Tables["users"].Rows[0]["password"];

                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }


        }

        private User GetUser(User user)
        {
            try
            {
                User userval = new User();
                String query = "select * from users where username = \'" + user.UserName + "\'";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "users");

                if (myDataSet.Tables["users"].Rows.Count < 1)
                {
                    Log.Instance.CreateEntry("user not found in database " + user.UserName);
                    return null;
                }

                userval.UserName =(String) myDataSet.Tables["users"].Rows[0]["username"];
                userval.ID = (int)myDataSet.Tables["users"].Rows[0]["ID"];
                userval.Password = (String)myDataSet.Tables["users"].Rows[0]["password"];


                return userval;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }


        }

        public bool Login(User user, string password)
        {
            try
            {
                User userDB = GetUser(user);

                if (userDB == null)
                {
                    return false;
                }

                string hashedpassword = Security.GetHash(password);
                
                if (userDB.Password == hashedpassword)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }

        }


        

        public static bool CreateUser(ref User user)
        {
            try
            {
                //todo return back the inserted id.
                using (OleDbDataAdapter da = new OleDbDataAdapter())
                using (OleDbCommandBuilder bld = new OleDbCommandBuilder(da))
                {
                    bld.QuotePrefix = "[";  // these are
                    bld.QuoteSuffix = "]";  //   important!

                    da.SelectCommand = new OleDbCommand(
                            "SELECT [ID], [UserName], [Password] " +
                            "FROM [Users] " +
                            "WHERE False",
                            DatabaseController.Instance().Connection);

                    using (System.Data.DataTable dt = new System.Data.DataTable("Users"))
                    {
                        // create an empty DataTable with the correct structure
                        da.Fill(dt);

                        System.Data.DataRow dr = dt.NewRow();
                        dr["UserName"] = user.UserName;
                        dr["Password"] = user.Password;
                        dt.Rows.Add(dr);

                        da.Update(dt);  // write new row back to database
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return false;
            }
        }


        public static String GetStudentName(int p)
        {
            try
            {
                String query = "select * from   users where id= " + p + ";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "users");

                if (myDataSet.Tables["users"].Rows.Count < 1)
                {

                    return "UNKNOWN";
                }
                else
                {
                    String subject = (String)myDataSet.Tables["users"].Rows[0]["username"];
                    return subject;
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return "UNKNOWN";
            }
        }

        public static List<User> GetAllUsers()
        {
            List<User> students = new List<User>();
            try
            {
                String query = "select * from   users;";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "users");

                if (myDataSet.Tables["users"].Rows.Count < 1)
                {
                    return students;
                }
                else
                {
                    for (int i = 0; i < myDataSet.Tables["users"].Rows.Count; i++)
                    {
                        User user = new User();
                        user.UserName = (String)myDataSet.Tables["users"].Rows[i]["username"];
                        user.ID = (int)myDataSet.Tables["users"].Rows[i]["id"];
                        user.Password = (String)myDataSet.Tables["users"].Rows[i]["password"];
                        user.Roles = GetUserRoles(user);
                        students.Add(user);

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

        private static List<Roles> GetUserRoles(User userI)
        {
            List<Roles> roles = new List<Roles>();
            try
            {
                String query = "select * from userroles,roles where userroles.roleid = roles.id and userroles.userid ="+ userI.ID +";";
                OleDbCommand myAccessCommand = new OleDbCommand(query, DatabaseController.Instance().Connection);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet);

                if (myDataSet.Tables["roles"].Rows.Count < 1)
                {
                    return roles;
                }
                else
                {
                    for (int i = 0; i < myDataSet.Tables["roles"].Rows.Count; i++)
                    {
                        Roles role = new Roles();
                        role.ID = (int)myDataSet.Tables["roles"].Rows[i]["roleid"];
                        role.Description = (String)myDataSet.Tables["roles"].Rows[i]["description"];
                        roles.Add(role);

                    }
                }

                return roles;
            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                return null;
            }

        }

        public static bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
