using ExaminerProLib.DataLayer.Binding;
using ExaminerProLib.DataLayer.Exam;
using ExaminerProLib.Utils;
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
    /// Interaction logic for ExamCreate.xaml
    /// </summary>
    public partial class ExamCreate : Window
    {
        public ExamCreate()
        {
            InitializeComponent();
            InitControls();

        }

        private void InitControls()
        {
            //Popluate the combo boxes.
            //Bind the comboboxes.
            DataTable subjects = DataBinding.GetSubjects();
            cboSubject.ItemsSource = subjects.DefaultView;
            cboSubject.DisplayMemberPath = subjects.Columns["subject"].ToString();
            cboSubject.SelectedValuePath = subjects.Columns["id"].ToString();
            cboSubject.SelectedIndex = 0;
            
            DataTable grade = DataBinding.GetGrades();
            cboGrade.ItemsSource = grade.DefaultView;
            cboGrade.DisplayMemberPath = grade.Columns["description"].ToString();
            cboGrade.SelectedValuePath = grade.Columns["number"].ToString();
            cboGrade.SelectedIndex = 0;

            DataTable profiles = DataBinding.GetQuestionProfiles();
            cboQuestionProfile.ItemsSource = profiles.DefaultView;
            cboQuestionProfile.DisplayMemberPath = profiles.Columns["name"].ToString();
            cboQuestionProfile.SelectedValuePath = profiles.Columns["id"].ToString();
            cboQuestionProfile.SelectedIndex = 0;

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    Exam exam = new Exam();
                    exam.Name = textExamName.Text;
                    exam.QuestionId = (int)cboQuestionProfile.SelectedValue;
                    exam.GradeId = (int)cboGrade.SelectedValue;
                    exam.SubjectId = (int)cboSubject.SelectedValue;
                    if (ExamHelper.SaveExam(ref exam))
                    {
                        MessageBox.Show("The Exam has been saved. ");
                    }
                    else
                    {
                        MessageBox.Show("The Exam could not be saved. ");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Exam could not be saved. ");
                Log.Instance.LogException(ex);
            }

        }

        private bool ValidateInput()
        {
            errormessage.Text = "";
            String error = "";

            if (textExamName.Text.Length < 1)
            {
                error += "Please enter a valid value to name.";
            }

            if(cboSubject.SelectedValue==null) {
                error += "Please select a subject.";
            }

            if (cboGrade.SelectedValue == null)
            {
                error += "Please select a grade.";
            }

            if (cboQuestionProfile.SelectedValue == null)
            {
                error += "Please select a question profile.";
            }

            if(error.Length > 0 ) {
                errormessage.Text = error;
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
