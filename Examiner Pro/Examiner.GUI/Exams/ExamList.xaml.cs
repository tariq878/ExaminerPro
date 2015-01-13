using Examiner_Pro.Examiner.GUI.Exams.Attempt;
using ExaminerProLib.DataLayer.Exam;
using ExaminerProLib.DataLayer.Grade;
using ExaminerProLib.DataLayer.Question;
using ExaminerProLib.DataLayer.Subject;
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

namespace Examiner_Pro.Examiner.GUI.Exams
{
    /// <summary>
    /// Interaction logic for ExamList.xaml
    /// </summary>
    public partial class ExamList : Window
    {
       List<Exam> _exams = new List<Exam>();

        public class LvDataE
        {
            public String Qset { get; set; }
            public String Name { get; set; }
            public String Subject { get; set; }
            public String Grade { get; set; }
            public int nGrade { get; set; }
            public int nSubject { get; set; }
            public int nQset { get; set; }

        }


        public ExamList()
        {
            InitializeComponent();

            RefreshExamList();
        }


        private void ButtonAttempt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LvDataE data = (LvDataE)lvExams.SelectedItems[0];
                Exam exam = _exams.Find(item => item.Name == data.Name);
                MessageBoxResult result = MessageBox.Show("Are you sure you want to start the exam attempt?", "Start Attempt !", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        //Start the question attempt wizard.
                        ExamAttempt dialog = new ExamAttempt(exam);
                        dialog.ShowDialog();
                            
                        break;
                    default:
                        return;
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
            LvDataE data = (LvDataE)lvExams.SelectedItems[0];

            if (data == null)
            {
                btnDelete.IsEnabled = false;
            }
            else
            {
                btnDelete.IsEnabled = true;
            }
        }


        private void RefreshExamList()
        {
            try
            {
                lvExams.Items.Clear();
                _exams = ExamHelper.GetAllExamsAssigned(3);

                foreach (Exam profile in _exams)
                {
                    LvDataE data = new LvDataE();
                    data.Name = profile.Name;
                    data.nGrade = profile.GradeId;
                    data.nQset = profile.QuestionId;
                    data.nSubject = profile.SubjectId;
                    data.Subject = SubjectHelper.SubjectGetName(profile.SubjectId);
                    data.Grade = GradeHelper.GetGradeName(profile.GradeId);
                    data.Qset = QuestionHelper.GetQuestionName(profile.QuestionId);
                    lvExams.Items.Add(data);
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                MessageBox.Show("Could not load all the quesitons, please fix the error and retry !");
                //this.Close();
            }
        }

    }
}
