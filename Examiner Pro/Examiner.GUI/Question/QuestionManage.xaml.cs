using ExaminerProLib.DataLayer.Question;
using ExaminerProLib.Utils;
using Microsoft.Win32;
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

namespace Examiner_Pro.Examiner.GUI.Question
{
    /// <summary>
    /// Interaction logic for QuestionManage.xaml
    /// </summary>
    public partial class QuestionManage : Window
    {
        List<QuestionProfile> questions = new List<QuestionProfile>();

        public class LvDataQ
        {
            public int Id { get; set; }
            public String Title { get; set; }
            public int QCount { get; set; }
        }


        public QuestionManage()
        {
            InitializeComponent();

            RefreshQuestionList();

            btnExport.IsEnabled = true;
            btnDelete.IsEnabled = true;

        }

        private void RefreshQuestionList()
        {
            try
            {
                lvQuestions.Items.Clear();
                questions = QuestionHelper.GetAllQuestions();

                foreach (QuestionProfile profile in questions)
                {
                    lvQuestions.Items.Add(new LvDataQ { Id = profile.ID, Title = profile.ProfileName, QCount = profile.Questions.Count });
                }

            }
            catch (Exception ex)
            {
                Log.Instance.LogException(ex);
                MessageBox.Show("Could not load all the quesitons, please fix the error and retry !");
                //this.Close();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LvDataQ data = (LvDataQ)lvQuestions.SelectedItems[0];
                QuestionProfile profile = questions.Find(item => item.ProfileName == data.Title);
                if (QuestionHelper.DeleteQuestion(profile))
                {
                    MessageBox.Show("The question has been deleted successfully.");
                    RefreshQuestionList();
                }
                else
                {
                    MessageBox.Show("The question has could not be deleted.");
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
            LvDataQ data = (LvDataQ)lvQuestions.SelectedItems[0];

            if (data == null)
            {
                btnDelete.IsEnabled = false;
                btnExport.IsEnabled = false;
            }
            else
            {
                btnDelete.IsEnabled = true;
                btnExport.IsEnabled = true;
            }
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LvDataQ data = (LvDataQ)lvQuestions.SelectedItems[0];
                QuestionProfile profile = questions.Find(item => item.ProfileName == data.Title);
                ExportUtils.ExportQuestionProfile(profile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select an item to delete.");
                Log.Instance.LogException(ex);
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
                QuestionProfile profile = ExportUtils.ImportQuestionProfile(filename);

                if (profile != null)
                {
                    QuestionProfile profile1 = questions.Find(item => item.ProfileName == profile.ProfileName);

                    if (profile1 == null)
                    {
                        if (QuestionHelper.SaveQuestion(ref profile))
                        {
                            MessageBox.Show("The exam imported succesfully.");
                            RefreshQuestionList();

                        } else {

                             MessageBox.Show("The exam could not be saved, please try again later.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("The exam profile with this name already esists. please load another file.");
                    }
                }
                else
                {
                    MessageBox.Show("The file could not be loaded. Pleasecheck the file and try again.");
                }

            }

        }
    }
}
