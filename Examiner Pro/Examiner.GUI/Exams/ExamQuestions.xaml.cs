using Examiner_Pro.Examiner.GUI.Exams.AddWizard;
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
    /// Interaction logic for ExamQuestions.xaml
    /// </summary>
    public partial class ExamQuestions : Window
    {
        public ExamQuestions()
        {
            InitializeComponent();
        }




        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                AddQuestion1 q1 = new AddQuestion1();

                if (q1.ShowDialog() == true)
                {
                    //Get detials of added questiona and display to the grid.


                }
                else
                {
                    MessageBox.Show("User Cancelled the question creation wizard");
                }


            }

            //AddQuestionWizard wizard = new AddQuestionWizard();
            //wizard.ShowDialog();

            /*
            ExamQuestionAddWizard wizard = new ExamQuestionAddWizard();
            bool dialogResult = (bool)wizard.ShowDialog();
            if (dialogResult)
            {
                MessageBox.Show(string.Format("{0}\n{1}\n{2}", wizard.WizardData.DataItem1, wizard.WizardData.DataItem2, wizard.WizardData.DataItem3));
            }
            else
            {
                MessageBox.Show("Canceled.");
            } */
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
    }
}
