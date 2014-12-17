using ExaminerProLib.DataLayer.Binding;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Examiner_Pro.Examiner.GUI.Exams
{
    /// <summary>
    /// Interaction logic for CreateCourse.xaml
    /// </summary>
    public partial class CreateCourse : Window
    {
        public CreateCourse()
        {
            InitializeComponent();

            CleanContents();

            //Bind the comboboxes.
            DataTable grades = DataBinding.GetGrades();
            cboGrade.ItemsSource = grades.DefaultView;
            cboGrade.DisplayMemberPath = grades.Columns["description"].ToString();
            cboGrade.SelectedValuePath = grades.Columns["number"].ToString();

            DataTable subjects = DataBinding.GetSubjects();
            cboSubject.ItemsSource = subjects.DefaultView;
            cboSubject.DisplayMemberPath = subjects.Columns["subject"].ToString();
            cboSubject.SelectedValuePath = subjects.Columns["id"].ToString();
 
        }

        private void CleanContents()
        {
            txtCourseName.Text = "";
            errormessage.Text = "";
            txtDuration.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Cancel.   
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Validate Data.
            if (ValidateData())
            {


            } 
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //Validate Data.
            if (ValidateData())
            {


                //Lets add questions to exam now.
                ExamQuestions dlgQuestions = new ExamQuestions();
                dlgQuestions.ShowDialog();

            }
        }

        private bool ValidateData()
        {
            errormessage.Text = "";
            String error = "";
            if (txtCourseName.Text.Length < 1)
               error += "Please enter a valid course name.";

            if (txtDuration.Text.Length < 1)
                error += "Please enter a valid duration.";

            if (cboGrade.SelectedItem == null)
                error += "Please enter a grade name.";

            if (cboSubject.SelectedItem == null)
                error += "Please enter a subject name.";

            errormessage.Text = error;

            return (error.Length > 0 ? false : true);
        }
    }
}
