using ExaminerProLib.DataLayer.Users;
using ExaminerProLib.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Examiner_Pro.Examiner.GUI.Users
{
    /// <summary>
    /// Interaction logic for UserManage.xaml
    /// </summary>
    public partial class UserManage : Window
    {
        List<User> _user = new List<User>();

        public class LvDataU
        {
            public String username { get; set; }
            public String role { get; set; }
            public String created { get; set; }

        }

        public UserManage()
        {
            InitializeComponent();
            RefreshStudentList();
        }

        private void RefreshStudentList()
        {
            try
            {
                lvStudent.Items.Clear();
                _user = UserHelper.GetAllUsers();

                foreach (User user in _user)
                {
                    LvDataU data = new LvDataU();
                    data.username = user.UserName;
                    data.role= (user.Roles[0].Description);
                    data.created = "todo";
                    lvStudent.Items.Add(data);
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                MessageBox.Show("Could not load all the users, please fix the error and retry !");
                //this.Close();
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LvDataU data = (LvDataU)lvStudent.SelectedItems[0];

            if (data == null)
            {
                btnDelete.IsEnabled = false;
            }
            else
            {
                btnDelete.IsEnabled = true;
            }
        }


        private void ButtonImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "XML Files (.xml)|*.xml|All Files (*.*)|*.*";
            dialog.FilterIndex = 0;

            dialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = dialog.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                String filename = dialog.FileName;
                List<User> users = ExportUtils.ImportUsers(filename);

                if (users != null)
                {

                    for (int i = 0; i < users.Count; i++)
                    {
                        User user = users[i];
                        //Lets find if it already exists.
                        User find = _user.Find(item => item.UserName == user.UserName);

                        if (find == null)
                        {
                            if (!UserHelper.CreateUser(ref user))
                            {
                                MessageBox.Show("The student wint name " + user.UserName + " already exists so skipped.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The student wint name " + user.UserName + " already exists so skipped.");
                        }
                    }

                    RefreshStudentList();
                }
                else
                {
                    MessageBox.Show("The file could not be loaded. Pleasecheck the file and try again.");
                }

            }

        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ExportUtils.ExperortUsers(_user);
                MessageBox.Show("File successfully exported.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("The items could not be exported.");
                Log.Instance.LogException(ex);
            }

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LvDataU data = (LvDataU)lvStudent.SelectedItems[0];
                User user = _user.Find(item => item.UserName == data.username);
                if (UserHelper.DeleteUser(user))
                {
                    MessageBox.Show("The user has been deleted successfully.");
                    RefreshStudentList();
                }
                else
                {
                    MessageBox.Show("The user has could not be deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select an item to delete.");
                Log.Instance.LogException(ex);
            }

        }
    }
}
