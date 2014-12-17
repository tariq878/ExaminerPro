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
using AvalonWizard;
using System.Data;
using ExaminerProLib.DataLayer.Binding;

namespace Examiner_Pro.Examiner.GUI.Exams.AddWizard
{
    /// <summary>
    /// Interaction logic for AddQuestionWizard.xaml
    /// </summary>
    public partial class AddQuestionWizard : Window
    {



        public AddQuestionWizard()
        {
            InitializeComponent();

            //Popluate the combo boxes.
            //Bind the comboboxes.
            DataTable types = DataBinding.GetQuestionTypes();
            cboQuestionType.ItemsSource = types.DefaultView;
            cboQuestionType.DisplayMemberPath = types.Columns["type"].ToString();
            cboQuestionType.SelectedValuePath = types.Columns["number"].ToString();

            DataTable numbers = DataBinding.GetQuestionNumbers();
            cboNumChoices.ItemsSource = numbers.DefaultView;
            cboNumChoices.DisplayMemberPath = numbers.Columns["question"].ToString();
            cboNumChoices.SelectedValuePath = numbers.Columns["number"].ToString();


            foreach (var page in wizard.Pages)
            {
                page.Commit += nextButton_Click;
                page.Rollback += BackButton_Click;
            }

            wizard.Cancelled += cancelButton_Click;
            wizard.Finished += finishButton_Click;
            
        }

        private void nextButton_Click(object sender, WizardPageConfirmEventArgs e)
        {

            
             String test = e.Page != null ? e.Page.Header.ToString() : "null";
            String EventName = e.RoutedEvent.Name;
            String ParameterName = "Cancel";
            String ParameterValue = e.Cancel.ToString();
            MessageBox.Show("next Clicked");
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Finish Clicked");
        }

        
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancelled Clicked");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancelled Clicked");
        }

        private void cboQuestionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int type = (int)cboQuestionType.SelectedValue;

            titleNumQuestions.Visibility = (type == 3 ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible);
            cboNumChoices.Visibility = (type == 3 ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible);

        }

    }

    
}
