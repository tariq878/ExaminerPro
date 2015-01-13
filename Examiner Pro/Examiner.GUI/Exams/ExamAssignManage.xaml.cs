using ExaminerProLib.DataLayer.Exam;
using ExaminerProLib.DataLayer.Grade;
using ExaminerProLib.DataLayer.Student;
using ExaminerProLib.DataLayer.Users;
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
    /// Interaction logic for ExamAssignManage.xaml
    /// </summary>
    public partial class ExamAssignManage : Window
    {

        List<ExamAssignO> _exams = new List<ExamAssignO>();
        public class LvDataEA
        {
            public int nid { get; set; }
            public String id { get; set; }

            public int nexam { get; set; }
            public String exam { get; set; }


            public int naby { get; set; }
            public String aby { get; set; }

            public bool bag { get; set; }
            public String ag { get; set; }


            public int nat { get; set; }
            public String at { get; set; }

            public int count { get; set; }
        }



        public ExamAssignManage()
        {
            InitializeComponent();

            RefreshExamList();
        }


        private void RefreshExamList()
        {
            try
            {
                lvExams.Items.Clear();
                _exams = ExamHelper.GetAllExamAssignO();

                foreach (ExamAssignO profile in _exams)
                {
                    LvDataEA data = new LvDataEA();
                    
                    data.id = profile.Id.ToString();
                    data.nid = profile.Id;
                    data.nexam = profile.ExamId;
                    data.exam = ExamHelper.GetExamName(profile.ExamId); ;
                    data.naby = profile.UserId;
                    data.aby = UserHelper.GetStudentName(profile.UserId);
                    data.bag = profile.IsToGrade;
                    data.ag = (profile.IsToGrade==true?"Grade":"Student");
                    if (profile.IsToGrade == true)
                    {
                        data.nat = profile.GradeId;
                        data.at = GradeHelper.GetGradeName(profile.GradeId);
                    }
                    else
                    {
                        data.nat = profile.StudentId;
                        data.at = StudentHelper.GetStudentName(profile.StudentId);
                    }
                    
                    data.count = profile.StudentCount;

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


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LvDataEA data = (LvDataEA)lvExams.SelectedItems[0];

            if (data == null)
            {
                btnDelete.IsEnabled = false;
            }
            else
            {
                btnDelete.IsEnabled = true;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
