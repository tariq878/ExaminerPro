using ExaminerProLib.DataLayer.Student;
using ExaminerProLib.DataLayer.Users;
using ExaminerProLib.Utils;
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
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.errormessage.Text = "";
            //We need to perform the login and set the login to true.
            UserHelper helper = new UserHelper();
            User user = new User();
            user.UserName = textBoxFirstName.Text;
            if(helper.Login(ref user, passwordBox1.Password))
            {
                m = new Main(); // Creates but wont show

                //Set the username to the main controller of the applicaiton.
                SessionUtil.IsStudent = false;
                SessionUtil.UserId = user.ID;

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

        #region Login as Student

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.errormessage1.Text = "";


            if (ValidateStudent())
            {
                StudentO student = new StudentO();
                    

                student.RegNumber = Int32.Parse(txtStudentId.Text);

                if (StudentHelper.StudentExists(ref student))
                {
                    m = new Main(); // Creates but wont show

                    SessionUtil.IsStudent = true;
                    SessionUtil.StudentId = student.RegNumber;
                    t = new Timer(new TimerCallback(CloseWindow), null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, -1));

                }
                else
                {
                    errormessage1.Text = "The student registration number does not exist!";
                }
            }
            
        }

        private bool ValidateStudent()
        {
            errormessage1.Text = "";
            if (txtStudentId.Text.Length == 0)
            {
                errormessage1.Text += "Please enter a valid student registration number!";
            } else {

                try
                {
                    int test = Int32.Parse(txtStudentId.Text);
                }
                catch (Exception ex)
                {
                    errormessage1.Text += "Registration number must be in numeric form!";
                }

            }

            return (this.errormessage1.Text.Length == 0);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
