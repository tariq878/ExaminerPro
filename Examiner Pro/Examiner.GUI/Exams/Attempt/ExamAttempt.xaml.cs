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

            Uri iconUri = new Uri("pack://siteoforigin:,,,/Media/drawing.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

            _exam = exam;
            _profile = QuestionHelper.GetAllQuestionById(_exam.QuestionId);
            _totalquestions = _profile.Questions.Count;

            RenderControls(_profile.Questions[_currentquestion]);

        }

        private void RenderControls(QuestionInfo questionInfo)
        {
            //1. Clear the grid contents
            ClearGrid();

            RenderButtons();

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col1.Width = new GridLength(15, GridUnitType.Star);
            col2.Width = new GridLength(85, GridUnitType.Star);
            gridQuestions.ColumnDefinitions.Add(col1);
            gridQuestions.ColumnDefinitions.Add(col2);


            //Lets put the text to the grid.
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(30);
            gridQuestions.RowDefinitions.Add(row);

            TextBlock block = new TextBlock();
            block.FontSize = 16;
            block.Foreground = Brushes.BlueViolet;
            block.Margin = new Thickness(10, 3, 3, 3);
            if(questionInfo.QuestionText.EndsWith("?"))
                block.Text = questionInfo.QuestionText;
            else
                block.Text = questionInfo.QuestionText + "?";
            Grid.SetRow(block, 0);
            Grid.SetColumn(block, 0);
            Grid.SetColumnSpan(block, 2);
            block.Name = "block_" + questionInfo.ID;
            RegisterControl(block.Name, block);
            gridQuestions.Children.Add(block);

            //Now lets render the question.
            switch (questionInfo.Type)
            {
                case QuestionType.MCQ:
                  
                    for (int i = 0; i < questionInfo.NumOptions; i++)
                    {
                        row = new RowDefinition();
                        //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                        row.Height = new GridLength(25);
                        gridQuestions.RowDefinitions.Add(row);

                        RadioButton btnRadio = new RadioButton();
                        Grid.SetRow(btnRadio, i+1);
                        Grid.SetColumn(btnRadio, 0);
                        btnRadio.Margin = new Thickness(3, 3, 3, 3);
                        btnRadio.Name = "rdo"  + i.ToString();
                        RegisterControl(btnRadio.Name, btnRadio);
                        gridQuestions.Children.Add(btnRadio);


                        //Add text box.
                        TextBox txtBox = new TextBox();
                        txtBox.Margin = new Thickness(3, 3, 3, 3);
                        txtBox.Text = questionInfo.Questions[i].DisplayText;
                        Grid.SetRow(txtBox, i+1);
                        Grid.SetColumn(txtBox, 1);
                        txtBox.Name = "txt" + i.ToString();
                        RegisterControl(txtBox.Name, txtBox);
                        gridQuestions.Children.Add(txtBox);
                    }

                    break;
                case QuestionType.Multiple:

                    for (int i = 0; i < questionInfo.NumOptions; i++)
                    {
                        row = new RowDefinition();
                        //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                        row.Height = new GridLength(25);
                        gridQuestions.RowDefinitions.Add(row);

                        CheckBox btnRadio = new CheckBox();
                        Grid.SetRow(btnRadio, i+1);
                        Grid.SetColumn(btnRadio, 0);
                        btnRadio.Margin = new Thickness(3, 3, 3, 3);
                        btnRadio.Name = "chk" + i.ToString();
                        RegisterControl(btnRadio.Name, btnRadio);
                        btnRadio.Content = "";
                        gridQuestions.Children.Add(btnRadio);


                        //Add text box.
                        TextBox txtBox = new TextBox();
                        txtBox.Margin = new Thickness(3, 3, 3, 3);
                        txtBox.Text = questionInfo.Questions[i].DisplayText;
                        Grid.SetRow(txtBox, i+1);
                        Grid.SetColumn(txtBox, 1);
                        txtBox.Name = "txt" +  i.ToString();
                        RegisterControl(txtBox.Name, txtBox);
                        gridQuestions.Children.Add(txtBox);
                    }


                    break;
                case QuestionType.TF:


                    for (int i = 0; i < questionInfo.NumOptions; i++)
                    {
                        row = new RowDefinition();
                        //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                        row.Height = new GridLength(25);
                        gridQuestions.RowDefinitions.Add(row);

                        RadioButton btnRadio = new RadioButton();
                        Grid.SetRow(btnRadio, i+1);
                        Grid.SetColumn(btnRadio, 0);
                        btnRadio.Margin = new Thickness(3, 3, 3, 3);
                        btnRadio.Name = "rdo" + i.ToString();
                        RegisterControl(btnRadio.Name, btnRadio);
                        gridQuestions.Children.Add(btnRadio);


                        //Add text box.
                        TextBox txtBox = new TextBox();
                        txtBox.Margin = new Thickness(3, 3, 3, 3);
                        txtBox.Text = questionInfo.Questions[i].DisplayText;
                        Grid.SetRow(txtBox, i+1);
                        Grid.SetColumn(txtBox, 1);
                        txtBox.Name = "txt"  + i.ToString();
                        RegisterControl(txtBox.Name, txtBox);
                        gridQuestions.Children.Add(txtBox);
                    }



                    break;
            }

        }

        private void ClearGrid()
        {
            gridQuestions.RowDefinitions.Clear();
            gridQuestions.ColumnDefinitions.Clear();

            gridQuestions.Children.Clear();


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
            if (_currentquestion + 1 < _totalquestions)
            {
                _profile.Questions[_currentquestion].Correct = QuestionStatus.Skipped;
                RenderControls(_profile.Questions[++_currentquestion]);
            }
            else
            {
                //Finish and save ansers.

            }
        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            // 1. Make sure question is answered
            // 2. Store the uesr answer.
            // 3. Render previous question if more otherwise finish and submit the results.
            RenderControls(_profile.Questions[--_currentquestion]);
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            bool answergiven = false;
            // 1. Make sure question is answered
            // 2. Store the uesr answer.
            // 3. Render next question if more otherwise finish and submit the results.
            QuestionInfo question = _profile.Questions[_currentquestion];
            question.Correct = QuestionStatus.Correct;
            for (int i = 0; i < question.NumOptions; i++)
            {
                TextBox txtBox = (TextBox)gridQuestions.FindName("txt" + i.ToString());
                QuestionOption option = question.Questions.Find(item => item.DisplayText == txtBox.Text);
                if (question.Type == QuestionType.TF || question.Type == QuestionType.MCQ)
                {
                    RadioButton btn = (RadioButton)gridQuestions.FindName("rdo" + i.ToString());
                    option.Answered = (btn.IsChecked == true ? true : false);
                }
                else
                {
                    CheckBox btn = (CheckBox)gridQuestions.FindName("chk" + i.ToString());
                    option.Answered = (btn.IsChecked == true ? true : false);
                }

                if (option.Answered == true)
                {
                    answergiven = true;
                }

                if (option.Correct != option.Answered)
                {
                    question.Correct = QuestionStatus.Wrong;
                }
            }

            if (answergiven == false)
            {
                MessageBox.Show("Please select one answer!");
                return;
            }


            if (_currentquestion + 1 < _totalquestions)
            {
                //Save to the database the attempt.
                RenderControls(_profile.Questions[++_currentquestion]);
            }
            else
            {
                //Save to database the attempt.

            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            //1. Mark the attempt as cancelled. Dont store the results as well.
            RenderControls(_profile.Questions[++_currentquestion]);
        }


        void RegisterControl<T>(string textBoxName, T textBox)
        {
            if ((T)this.FindName(textBoxName) != null)
                this.UnregisterName(textBoxName);
            this.RegisterName(textBoxName, textBox);
        }
    }
}
