using Examiner_Pro.Examiner.GUI.Question.AddWizard;
using ExaminerProLib.DataLayer.Question;
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
    /// Interaction logic for QuestionAdd.xaml
    /// </summary>
    public partial class QuestionAdd : Window
    {
        public class LvData
        {
            public int Id { get; set; }
            public String tType { get; set; }
            public int QCount { get; set; }
        }

        QuestionProfile _profile = new QuestionProfile();

        public QuestionAdd()
        {
            InitializeComponent();

 
        }




        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                QuestionAddPage1 q1 = new QuestionAddPage1();

                if (q1.ShowDialog() == true)
                {
                    //Get detials of added questiona and display to the grid.
                    QuestionInfo question = q1.QuestionG;
                    _profile.Questions.Add(question);

                    RefreshList();
                }
                else
                {
                    MessageBox.Show("User Cancelled the question creation wizard");
                }


            }

        }

        private void RefreshList()
        {
            lvQuestions.Items.Clear();

            for (int i = 0; i < _profile.Questions.Count; i++)
            {
                QuestionInfo q = _profile.Questions[i];
                lvQuestions.Items.Add(new LvData { Id = i , tType = q.Type.ToString() , QCount=q.Questions.Count } );

            }


        }

        private bool ValidateFields()
        {
            errormessage.Text = "";
            String error = "";

            if (textQuestionProfile.Text.Length < 1)
            {
                error += "Please enter a valid profile ID before proceeding";
            }

            errormessage.Text = error;

            if (errormessage.Text.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _profile.ProfileName = textQuestionProfile.Text;

            if (QuestionHelper.QuestionExists(ref _profile))
            {
                MessageBoxResult result = MessageBox.Show("Question already exisits, Overrite", "Qestion already present", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        QuestionHelper.DeleteQuestion(_profile);
                        break;
                    default:
                        return;
                }

              
            }

            //Save the Exam Result.
            if (QuestionHelper.SaveQuestion(ref _profile))
            {
                MessageBox.Show("The question profile has been saved.");
            }
            else
            {
                MessageBox.Show("The question profile could not be saved.");
            }

        }
   }

}