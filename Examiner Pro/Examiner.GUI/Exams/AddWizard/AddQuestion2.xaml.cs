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


namespace Examiner_Pro.Examiner.GUI.Exams.AddWizard
{
    /// <summary>
    /// Interaction logic for AddQuestion2.xaml
    /// </summary>
    public partial class AddQuestion2 : Window
    {
        Question _question;
        List<QuestionOption> _options;

        public List<QuestionOption> Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
            }

        }

        public AddQuestion2(Question question)
        {
            InitializeComponent();

            _question = question;
            //Create the controls based on the type of question
            switch (_question.Type)
            {
                case QuestionType.MCQ: //Multiple choice quesitons
                    CreateMQC();
                    break;
                case QuestionType.Multiple: //Multiple selectable quesitons
                    CreateMultiple();
                    break;
                case QuestionType.TF: //True False
                    CreateTF();
                    break;
            }

            _options = new List<QuestionOption>();

        }

        private void CreateTF()
        {
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col1.Width = new GridLength(15, GridUnitType.Star);
            col2.Width = new GridLength(85, GridUnitType.Star);
            gridContent.ColumnDefinitions.Add(col1);
            gridContent.ColumnDefinitions.Add(col2);


            for (int i = 0; i < 2; i++)
            {
                RowDefinition row = new RowDefinition();
                //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                row.Height = new GridLength(25);
                gridContent.RowDefinitions.Add(row);
            }

            for (int i = 0; i < 2; i++)
            {
                RadioButton btnRadio = new RadioButton();
                Grid.SetRow(btnRadio, i);
                Grid.SetColumn(btnRadio, 0);
                btnRadio.Margin = new Thickness(3, 3, 3, 3);
                btnRadio.Name = "rdo" + i.ToString();
                RegisterName(btnRadio.Name, btnRadio);
                gridContent.Children.Add(btnRadio);


                //Add text box.
                TextBox txtBox = new TextBox();
                txtBox.Margin = new Thickness(3, 3, 3, 3);
                txtBox.Text = "";
                Grid.SetRow(txtBox, i);
                Grid.SetColumn(txtBox, 1);
                txtBox.Name = "txt" + i.ToString();
                RegisterName(txtBox.Name, txtBox);
                gridContent.Children.Add(txtBox);


            }
        }

        private void CreateMultiple()
        {
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col1.Width = new GridLength(15, GridUnitType.Star);
            col2.Width = new GridLength(85, GridUnitType.Star);
            gridContent.ColumnDefinitions.Add(col1);
            gridContent.ColumnDefinitions.Add(col2);


            for (int i = 0; i < _question.NumOptions; i++)
            {
                RowDefinition row = new RowDefinition();
                //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                row.Height = new GridLength(25);
                gridContent.RowDefinitions.Add(row);
            }

            for (int i = 0; i < _question.NumOptions ; i++)
            {
                CheckBox btnRadio = new CheckBox();
                Grid.SetRow(btnRadio, i);
                Grid.SetColumn(btnRadio, 0);
                btnRadio.Margin = new Thickness(3, 3, 3, 3);
                btnRadio.Name = "chk" + i.ToString();
                this.RegisterName(btnRadio.Name, btnRadio);
                gridContent.Children.Add(btnRadio);

                //Add text box.
                TextBox txtBox = new TextBox();
                txtBox.Margin = new Thickness(3, 3, 3, 3);
                txtBox.Text = "";
                Grid.SetRow(txtBox, i);
                Grid.SetColumn(txtBox, 1);
                txtBox.Name = "txt" + i.ToString();
                this.RegisterName(txtBox.Name, txtBox);
                gridContent.Children.Add(txtBox);


            }
        }

        private void CreateMQC()
        {
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col1.Width = new GridLength(15, GridUnitType.Star);
            col2.Width = new GridLength(85, GridUnitType.Star);
            gridContent.ColumnDefinitions.Add(col1);
            gridContent.ColumnDefinitions.Add(col2);


            for (int i = 0; i < _question.NumOptions ; i++)
            {
                RowDefinition row = new RowDefinition();
                //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                row.Height = new GridLength(25);
                gridContent.RowDefinitions.Add(row);
            }

            for (int i = 0; i < _question.NumOptions; i++)
            {
                RadioButton btnRadio = new RadioButton();
                Grid.SetRow(btnRadio, i);
                Grid.SetColumn(btnRadio, 0);
                btnRadio.Margin = new Thickness(3, 3, 3, 3);
                btnRadio.Name = "rdo" + i.ToString();
                this.RegisterName(btnRadio.Name, btnRadio);
                gridContent.Children.Add(btnRadio);

                //Add text box.
                TextBox txtBox = new TextBox();
                txtBox.Margin = new Thickness(3, 3, 3, 3);
                txtBox.Text = "";
                Grid.SetRow(txtBox, i);
                Grid.SetColumn(txtBox, 1);
                txtBox.Name = "txt" + i.ToString();
                this.RegisterName(txtBox.Name, txtBox);
                gridContent.Children.Add(txtBox);


            }
        }

        internal void setQuestion(Question question)
        {
            _question = question;
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            errormessage.Text = "";

            //Validate the fields.
            if (ValidateInputs())
            {
                //All the inputs are valid. lets add question to the database against the question profile.
                //Popluate question contents.
                switch (_question.Type)
                {
                    case QuestionType.MCQ: //Multiple choice quesitons
                    case QuestionType.TF:  //True false;
                        for (int i = 0; i < _question.NumOptions; i++)
                        {
                            RadioButton btnRadio = (RadioButton)gridContent.FindName("rdo" + i.ToString());
                            TextBox txtBox = (TextBox)gridContent.FindName("txt" + i.ToString());
                            QuestionOption option = new QuestionOption();
                            option.DisplayText = txtBox.Text;
                            option.Correct = (btnRadio.IsChecked == true ? true : false);
                            _options.Add(option);
                        }
                        break;
                    case QuestionType.Multiple: //Multiple selectable quesitons
                        for (int i = 0; i < _question.NumOptions; i++)
                        {
                            CheckBox btnRadio = (CheckBox)this.FindName("chk" + i.ToString());
                            TextBox txtBox = (TextBox)this.FindName("txt" + i.ToString());
                            QuestionOption option = new QuestionOption();
                            option.DisplayText = txtBox.Text;
                            option.Correct = (btnRadio.IsChecked == true ? true : false);
                            _options.Add(option);
                        }
                        break;
                }
                this.DialogResult = true;

            }
        }

        private bool ValidateInputs()
        {
            String error = "";
            bool answermentioned = false;
            bool allselected = true;
            switch (_question.Type)
            {
                case QuestionType.MCQ: //Multiple choice quesitons

                    foreach (var elements in gridContent.Children)
                    {
                        if (elements.GetType() == new TextBox().GetType())
                        {
                            TextBox text = (TextBox)elements;
                            if (text.Text.Length < 1)
                                allselected = false;

                        }
                        else if (elements.GetType() == new RadioButton().GetType())
                        {
                            RadioButton rdo = (RadioButton)elements;
                            if (rdo.IsChecked == true)
                                answermentioned = true;

                        }


                    }

                    if (!answermentioned)
                        error += "Please select correct answer.";
                    if (allselected == false)
                        error += "Please enter all the values.";

                    if (error.Length > 0)
                    {
                        errormessage.Text = error;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case QuestionType.Multiple: //Multiple selectable quesitons
                    foreach (var elements in gridContent.Children)
                    {
                        if (elements.GetType() == new TextBox().GetType())
                        {
                            TextBox text = (TextBox)elements;
                            if (text.Text.Length < 1)
                                allselected = false;

                        }
                        else if (elements.GetType() == new CheckBox().GetType())
                        {
                            CheckBox rdo = (CheckBox)elements;
                            if (rdo.IsChecked == true)
                                answermentioned = true;

                        }


                    }

                    if (!answermentioned)
                        error += "Please select correct answer.";
                    if (allselected == false)
                        error += "Please enter all the values.";

                    if (error.Length > 0)
                    {
                        errormessage.Text = error;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case QuestionType.TF: //True False
                    foreach (var elements in gridContent.Children)
                    {
                        if (elements.GetType() == new TextBox().GetType())
                        {
                            TextBox text = (TextBox)elements;
                            if (text.Text.Length < 1)
                                allselected = false;

                        }
                        else if (elements.GetType() == new RadioButton().GetType())
                        {
                            RadioButton rdo = (RadioButton)elements;
                            if (rdo.IsChecked == true)
                                answermentioned = true;

                        }


                    }

                    if (!answermentioned)
                        error += "Please select correct answer.";
                    if (allselected == false)
                        error += "Please enter all the values.";

                    if (error.Length > 0)
                    {
                        errormessage.Text = error;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
            }

            return false;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


    }
}
