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
    /// Interaction logic for ExamAssign.xaml
    /// </summary>
    public partial class ExamAssign : Window
    {
        public ExamAssign()
        {
            InitializeComponent();

            InitControls();

        }

        private void InitControls()
        {
            cboTarget.Items.Add("Grade");
            cboTarget.Items.Add("Student");

            cboTarget.SelectedIndex = 0;


            DataTable exam = DataBinding.GetExams();
            cboExam.ItemsSource = exam.DefaultView;
            cboExam.DisplayMemberPath = exam.Columns["title"].ToString();
            cboExam.SelectedValuePath = exam.Columns["id"].ToString();
            cboExam.SelectedIndex = 0;

            DataTable grade = DataBinding.GetGrades();
            cboGradeStudent.ItemsSource = grade.DefaultView;
            cboGradeStudent.DisplayMemberPath = grade.Columns["description"].ToString();
            cboGradeStudent.SelectedValuePath = grade.Columns["number"].ToString();
            cboGradeStudent.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                ExamAssignO assing = new ExamAssignO();
                assing.ExamId = (int)cboExam.SelectedValue;
                assing.AssignDate = DateTime.Now;
                assing.GradeId = (int)cboGradeStudent.SelectedValue;
                assing.Id = -1;
                assing.IsToGrade = ( cboGradeStudent.SelectedIndex== 0 ? true : false);
                assing.StudentCount = -1;
                assing.StudentId = (int)cboGradeStudent.SelectedValue;
                assing.UserId = SessionUtil.UserId;


                if (ExamHelper.AssignExamInsert(ref assing))
                {
                    MessageBox.Show("The exam has been assigned");
                }
                else
                {
                    MessageBox.Show("The exam could not be assigned");
                }


            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                MessageBox.Show("The exam could not be assigned");

            }

        }


        private bool ValidateInput()
        {
            errormessage.Text = "";
            String error = "";

          

            if (cboTarget.SelectedValue == null)
            {
                error += "Please select a target.";
            }

            if (cboGradeStudent.SelectedValue == null)
            {
                error += "Please select a grade.";
            }

            if (cboExam.SelectedValue == null)
            {
                error += "Please select a exam to be taken.";
            }

       
            if (error.Length > 0)
            {
                errormessage.Text = error;
                return false;
            }

            return true;
        }


        private void cboTarget_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String target = cboTarget.SelectedItem.ToString();

            if (target.Equals("Grade"))
            {
                DataTable grade = DataBinding.GetGrades();
                cboGradeStudent.ItemsSource = grade.DefaultView;
                cboGradeStudent.DisplayMemberPath = grade.Columns["description"].ToString();
                cboGradeStudent.SelectedValuePath = grade.Columns["number"].ToString();
                cboGradeStudent.SelectedIndex = 0;

                titleGrade.Text = "Please select the grade id:";
            }
            else
            {
                DataTable students = DataBinding.GetStudents();
                cboGradeStudent.ItemsSource = students.DefaultView;
                cboGradeStudent.DisplayMemberPath = students.Columns["studentname"].ToString();
                cboGradeStudent.SelectedValuePath = students.Columns["regnum"].ToString();
                cboGradeStudent.SelectedIndex = 0;
                titleGrade.Text = "Please select the student id:";
            }
        }
    }
}
