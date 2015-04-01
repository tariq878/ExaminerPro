using Examiner_Pro.Examiner.GUI.Exams;
using Examiner_Pro.Examiner.GUI.Exams.Attempt;
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
           EnableMenus();
        }

        private void EnableMenus()
        {
            if (SessionUtil.IsStudent)
            {
                mnuAttempt.IsEnabled = true;
                mnuExams.IsEnabled = false;
                mnuFile.IsEnabled = false;
                mnuQuestion.IsEnabled = false;
                mnuSettings.IsEnabled = false;
                mnuStudent.IsEnabled = false;
                mnuUsers.IsEnabled = false;
            }
            else
            {
                mnuAttempt.IsEnabled = false;
                mnuExams.IsEnabled = true;
                mnuFile.IsEnabled = true;
                mnuQuestion.IsEnabled = true;
                mnuSettings.IsEnabled = false;
                mnuStudent.IsEnabled = true;
                mnuUsers.IsEnabled = true;

            }
        }

        #region Exams
        private void Menu_ExamNew(object sender, RoutedEventArgs e)
        {
            Log.Instance.CreateEntry("Starting the main windoiw");
            ExamCreate dialog = new ExamCreate();
            dialog.ShowDialog();
        }

        private void Menu_ExamManage(object sender, RoutedEventArgs e)
        {
            Log.Instance.CreateEntry("Starting the main windoiw");
            ExamManage dialog = new ExamManage();
            dialog.ShowDialog();
        }

        private void Menu_ExamAssign(object sender, RoutedEventArgs e)
        {
            Log.Instance.CreateEntry("Starting the main windoiw");
            ExamAssign dialog = new ExamAssign();
            dialog.ShowDialog();
        }

        private void Menu_ExamDeassign(object sender, RoutedEventArgs e)
        {
            Log.Instance.CreateEntry("Starting the main windoiw");
            ExamAssignManage dialog = new ExamAssignManage();
            dialog.ShowDialog();
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
            UserManage userForm = new UserManage();
            userForm.ShowDialog();
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

        #region Students
        private void Menu_studentEnrol(object sender, RoutedEventArgs e)
        {
            QuestionAdd dialog = new QuestionAdd();
            dialog.ShowDialog();
        }
        private void Menu_studentManage(object sender, RoutedEventArgs e)
        {
            QuestionManage dialog = new QuestionManage();
            dialog.ShowDialog();
        }
        #endregion

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Menu_FileExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Menu_FileAbout(object sender, RoutedEventArgs e)
        {
            //Show About Dialog.
            AboutExaminerPro about = new AboutExaminerPro();
            about.ShowDialog();
        }

        private void Menu_ExamAttempt(object sender, RoutedEventArgs e)
        {
            ExamList dialog = new ExamList();
            dialog.ShowDialog();
        }

    }
}
