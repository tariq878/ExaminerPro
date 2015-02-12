using ExaminerProLib.DataLayer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Examiner_Pro.Examiner.GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Main m;
        private Timer t;

        public LoginWindow()
        {
            InitializeComponent();

            textBoxFirstName.Text = "admin";
           passwordBox1.Password="admin";
        }

        private void ClearContent()
        {
            this.errormessage.Text = "";
            textBoxFirstName.Text = "";
            passwordBox1.Clear();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.errormessage.Text = "";
            //We need to perform the login and set the login to true.
            UserHelper helper = new UserHelper();
            User user = new User();
            user.UserName = textBoxFirstName.Text;
            if(helper.Login(user, passwordBox1.Password))
            {
                m = new Main(); // Creates but wont show

                t = new Timer(new TimerCallback(CloseWindow), null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));
            }
            else 
            {
                this.errormessage.Text = "Invalid username / password";
                //this.DialogResult = false;
            }

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Boolean Capslock = Console.CapsLock;
            if (Capslock == true)
            {
                PopupTextBlock.Text = "Caps Lock is On.";
                txtPasswordPopup.IsOpen = true;
            }
            else
            {
                txtPasswordPopup.IsOpen = false;
            }
        }


        private void CloseWindow(object info)
        {
            this.Dispatcher.Invoke((Action)(() => { m.Show(); Close(); }));
        }

    }
}
