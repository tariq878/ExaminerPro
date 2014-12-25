using ExaminerProLib.DataLayer.Binding;
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

namespace Examiner_Pro.Examiner.GUI.Exams.AddWizard
{
    /// <summary>
    /// Interaction logic for AddQuestion1.xaml
    /// </summary>
    public partial class AddQuestion1 : Window
    {
        Question _question;

        public Question QuestionG
        {
            get { return _question;  }
            set { _question = value;  }
        }

        public AddQuestion1()
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

            _question = new Question();

        }

        private void cboQuestionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int type = (int)cboQuestionType.SelectedValue;

            titleNumQuestions.Visibility = (type == 3 ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible);
            cboNumChoices.Visibility = (type == 3 ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible);

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            //Next is clicked, create a dynamic window based on the options provided.
            QuestionData data = new QuestionData();
            data.QuestionCount = (cboNumChoices.SelectedValue==null?0:(int)cboNumChoices.SelectedValue);
            data.Type = ( ((int)cboQuestionType.SelectedValue==1) ?QuestionType.MCQ:( ((int)cboQuestionType.SelectedValue==2) ?QuestionType.Multiple:QuestionType.TF));
            _question.Data = data;
            AddQuestion2 step2 = new AddQuestion2(data);
            step2.setData(data);

            if (step2.ShowDialog() == true)
            {
                _question.Questions = step2.Options;
                this.DialogResult = true;
            }
            else
            {
                //Dont add the requestion.
            }

        }

     

    }
}
