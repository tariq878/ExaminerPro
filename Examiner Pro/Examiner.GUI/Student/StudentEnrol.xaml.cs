using ExaminerProLib.DataLayer.Binding;
using ExaminerProLib.DataLayer.Student;
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

namespace Examiner_Pro.Examiner.GUI.Student
{
    /// <summary>
    /// Interaction logic for StudentEnrol.xaml
    /// </summary>
    public partial class StudentEnrol : Window
    {
        public StudentEnrol()
        {
            InitializeComponent();
            InitControls();

        }

        private void InitControls()
        {
            //Popluate the combo boxes.
            //Bind the comboboxes.
            DataTable grade = DataBinding.GetGrades();
            cboGrade.ItemsSource = grade.DefaultView;
            cboGrade.DisplayMemberPath = grade.Columns["description"].ToString();
            cboGrade.SelectedValuePath = grade.Columns["number"].ToString();
            cboGrade.SelectedIndex = 0;

            txtRegnumber.Text = "";
            txtUserName.Text = "";
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    StudentO student = new StudentO();
                    student.Name = txtUserName.Text;
                    student.RegNumber = int.Parse(txtRegnumber.Text);
                    student.GradeId = (int)cboGrade.SelectedValue;
                    if (StudentHelper.SaveStudent(ref student))
                    {
                        MessageBox.Show("The student has been saved. ");
                    }
                    else
                    {
                        MessageBox.Show("The student could not be saved. ");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The student could not be saved. ");
                Log.Instance.LogException(ex);
            }

        }

        private bool ValidateInput()
        {
            errormessage.Text = "";
            String error = "";

            if (txtUserName.Text.Length < 1)
            {
                error += "Please enter a valid value to name.";
            }

            if (txtRegnumber == null)
            {
                error += "Please select a subject.";
            }

            if (cboGrade.SelectedValue == null)
            {
                error += "Please select a grade.";
            }

            if (error.Length > 0)
            {
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
