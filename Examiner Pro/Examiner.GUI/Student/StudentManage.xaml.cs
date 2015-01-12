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
using ExaminerProLib.DataLayer.Student;
using ExaminerProLib.Utils;
using ExaminerProLib.DataLayer.Grade;
using Microsoft.Win32;

namespace Examiner_Pro.Examiner.GUI.Student
{
    /// <summary>
    /// Interaction logic for StudentManage.xaml
    /// </summary>
    public partial class StudentManage : Window
    {

        List<StudentO> _student = new List<StudentO>();

        public class LvDataS
        {
            public String Name { get; set; }
            public String Grade { get; set; }
            public int nGrade { get; set; }
            public int RegNum;
            
        }

        public StudentManage()
        {
            InitializeComponent();
            RefreshStudentList();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LvDataS data = (LvDataS)lvStudent.SelectedItems[0];
                StudentO student = _student.Find(item => item.Name == data.Name);
                if (StudentHelper.DeleteStudent(student))
                {
                    MessageBox.Show("The student has been deleted successfully.");
                    RefreshStudentList();
                }
                else
                {
                    MessageBox.Show("The student has could not be deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select an item to delete.");
                Log.Instance.LogException(ex);
            }

        }


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LvDataS data = (LvDataS)lvStudent.SelectedItems[0];

            if (data == null)
            {
                btnDelete.IsEnabled = false;
            }
            else
            {
                btnDelete.IsEnabled = true;
            }
        }

        private void RefreshStudentList()
        {
            try
            {
                lvStudent.Items.Clear();
                _student = StudentHelper.GetAllStudents();

                foreach (StudentO student in _student)
                {
                    LvDataS data = new LvDataS();
                    data.Name = student.Name;
                    data.nGrade = student.GradeId;
                    data.RegNum = student.RegNumber;
                    data.Grade = GradeHelper.GetGradeName(student.GradeId);
                    lvStudent.Items.Add(data);
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                MessageBox.Show("Could not load all the students, please fix the error and retry !");
                //this.Close();
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
                List<StudentO> students = ExportUtils.ImportStudents(filename);

                if (students != null)
                {

                    for (int i = 0 ; i < students.Count ; i++ )
                    {
                        StudentO student = students[i];
                        //Lets find if it already exists.
                        StudentO find = _student.Find(item => item.Name == student.Name);

                        if (find == null)
                        {
                            if (!StudentHelper.SaveStudent(ref student))
                            {
                                MessageBox.Show("The student wint name " + student.Name + " already exists so skipped.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The student wint name " +student.Name+ " already exists so skipped.");
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
                ExportUtils.ExportStudents(_student);
                MessageBox.Show("File successfully exported.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("The items could not be exported.");
                Log.Instance.LogException(ex);
            }

        }
    }
}
