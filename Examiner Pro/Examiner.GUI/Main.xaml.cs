using Examiner_Pro.Examiner.GUI.Question;
using Examiner_Pro.Examiner.GUI.Users;
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

namespace Examiner_Pro.Examiner.GUI
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        #region Exams
        private void Menu_NewClick(object sender, RoutedEventArgs e)
        {
            Log.Instance.CreateEntry("Starting the main windoiw");
            //CreateCourse userForm = new CreateCourse();
            //userForm.ShowDialog();
        }
        #endregion


        #region Users
        private void Menu_userNew(object sender, RoutedEventArgs e)
        {
            UserCreate userForm = new UserCreate();
            userForm.ShowDialog();
        }
        private void Menu_userDelete(object sender, RoutedEventArgs e)
        {

        }
        private void Menu_userReset(object sender, RoutedEventArgs e)
        {

        }
        private void Menu_userChangeRole(object sender, RoutedEventArgs e)
        {

        }
        #endregion


        #region Questions
        private void Menu_questionNew(object sender, RoutedEventArgs e)
        {
            QuestionAdd dialog = new QuestionAdd();
            dialog.ShowDialog();
        }
        private void Menu_questionManage(object sender, RoutedEventArgs e)
        {
            QuestionManage dialog = new QuestionManage();
            dialog.ShowDialog();
        }
        #endregion

    }
}
