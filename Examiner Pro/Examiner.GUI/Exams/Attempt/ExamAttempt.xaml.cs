using ExaminerProLib.DataLayer.Exam;
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

namespace Examiner_Pro.Examiner.GUI.Exams.Attempt
{
    /// <summary>
    /// Interaction logic for ExamAttempt.xaml
    /// </summary>
    public partial class ExamAttempt : Window
    {
        private Exam _exam;
        private QuestionProfile _profile;
        private int _totalquestions = 0;
        private int _currentquestion = 0;

        public ExamAttempt(Exam exam)
        {
            InitializeComponent();

            _exam = exam;
            _profile = QuestionHelper.GetAllQuestionById(_exam.QuestionId);
            _totalquestions = _profile.Questions.Count;

            RenderControls(_profile.Questions[_currentquestion]);

        }

        private void RenderControls(QuestionInfo questionInfo)
        {
            RenderButtons();

            //Now lets render the question.
            switch (questionInfo.Type)
            {
                case QuestionType.MCQ:
                    ColumnDefinition col1 = new ColumnDefinition();
                    ColumnDefinition col2 = new ColumnDefinition();
                    col1.Width = new GridLength(15, GridUnitType.Star);
                    col2.Width = new GridLength(85, GridUnitType.Star);
                    gridQuestions.ColumnDefinitions.Add(col1);
                    gridQuestions.ColumnDefinitions.Add(col2);

                    for (int i = 0; i < questionInfo.NumOptions; i++)
                    {
                        RowDefinition row = new RowDefinition();
                        //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                        row.Height = new GridLength(25);
                        gridQuestions.RowDefinitions.Add(row);

                        RadioButton btnRadio = new RadioButton();
                        Grid.SetRow(btnRadio, i);
                        Grid.SetColumn(btnRadio, 0);
                        btnRadio.Margin = new Thickness(3, 3, 3, 3);
                        btnRadio.Name = "rdo" + i.ToString();
                        RegisterName(btnRadio.Name, btnRadio);
                        gridQuestions.Children.Add(btnRadio);


                        //Add text box.
                        TextBox txtBox = new TextBox();
                        txtBox.Margin = new Thickness(3, 3, 3, 3);
                        txtBox.Text = questionInfo.Questions[i].DisplayText;
                        Grid.SetRow(txtBox, i);
                        Grid.SetColumn(txtBox, 1);
                        txtBox.Name = "txt" + i.ToString();
                        RegisterName(txtBox.Name, txtBox);
                        gridQuestions.Children.Add(txtBox);
                    }

                    break;
                case QuestionType.Multiple:




                    break;
                case QuestionType.TF:




                    break;
            }

        }

        private void RenderButtons()
        {
            if (_currentquestion > 0)
                btnPrevious.IsEnabled = true;
            else
                btnPrevious.IsEnabled = false;

            if (_currentquestion == _totalquestions - 1)
            {
                btnNext.Content = "Finish";

            }
            else
            {
                btnNext.Content = "Next";
            }
        }

        private void ButtonSkip_Click(object sender, RoutedEventArgs e)
        {
            //Set the status of question as skipped.
            //Render the next question.
        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            // 1. Make sure question is answered
            // 2. Store the uesr answer.
            // 3. Render previous question if more otherwise finish and submit the results.
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            // 1. Make sure question is answered
            // 2. Store the uesr answer.
            // 3. Render next question if more otherwise finish and submit the results.
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            //1. Mark the attempt as cancelled. Dont store the results as well.

        }
    }
}
