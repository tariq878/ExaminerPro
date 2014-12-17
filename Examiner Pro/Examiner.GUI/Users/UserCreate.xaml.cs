using ExaminerProLib.DataLayer.Users;
using ExaminerProLib.Utils;
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
    /// Interaction logic for UserCreate.xaml
    /// </summary>
    public partial class UserCreate : Window
    {
        public UserCreate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String error = "";
            errormessage.Text = "";
            //Perform validations.

            if (txtPassword.Password != txtPasswordCoonfirm.Password)
                error += "Passwords donot match.";

            if (txtUserName.Text.Length < 1)
                error += "Please enter username.";

            errormessage.Text = error;

            User user = new User();
            Roles roles = new Roles();
            user.Password = Security.GetHash(txtPassword.Password);
            user.UserName = txtUserName.Text;

            if (chkTeacher.IsChecked==true)
            {
                roles.ID = 1;
            }
            else
            {
                roles.ID = 2;
            }
            user.Roles.Add(roles);

            //Create a User.
            UserHelper helper = new UserHelper();
            helper.CreateUser(user);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Cancel
            
            this.Close();
        }
    }
}
