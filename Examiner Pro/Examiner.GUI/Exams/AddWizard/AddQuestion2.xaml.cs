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
        QuestionData _qdata;

        public AddQuestion2(QuestionData qdata)
        {
            InitializeComponent();

            _qdata = qdata;
            //Create the controls based on the type of question
            switch (_qdata.Type)
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
                gridContent.Children.Add(btnRadio);

                //Add text box.
                TextBox txtBox = new TextBox();
                txtBox.Margin = new Thickness(3, 3, 3, 3);
                txtBox.Text = " aksjdlasjdlasjdlkajslkddjasljdlkasjldkjaslkjdalk";
                Grid.SetRow(txtBox, i);
                Grid.SetColumn(txtBox, 1);
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


            for (int i = 0; i < _qdata.QuestionCount; i++)
            {
                RowDefinition row = new RowDefinition();
                //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                row.Height = new GridLength(25);
                gridContent.RowDefinitions.Add(row);
            }

            for (int i = 0; i < _qdata.QuestionCount; i++)
            {
                CheckBox btnRadio = new CheckBox();
                Grid.SetRow(btnRadio, i);
                Grid.SetColumn(btnRadio, 0);
                btnRadio.Margin = new Thickness(3, 3, 3, 3);
                gridContent.Children.Add(btnRadio);

                //Add text box.
                TextBox txtBox = new TextBox();
                txtBox.Margin = new Thickness(3, 3, 3, 3);
                txtBox.Text = " aksjdlasjdlasjdlkajslkddjasljdlkasjldkjaslkjdalk";
                Grid.SetRow(txtBox, i);
                Grid.SetColumn(txtBox, 1);
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
            

            for (int i = 0 ; i < _qdata.QuestionCount ; i++ )
            {
                RowDefinition row = new RowDefinition();
                //row.Height = new GridLength((100 / _qdata.QuestionCount > 8 ? 8 : 100 / _qdata.QuestionCount), GridUnitType.Star);
                row.Height = new GridLength(25);
                gridContent.RowDefinitions.Add(row);
            }

            for (int i = 0; i < _qdata.QuestionCount; i++)
            {
                RadioButton btnRadio = new RadioButton();
                Grid.SetRow(btnRadio, i);
                Grid.SetColumn(btnRadio, 0);
                btnRadio.Margin = new Thickness(3, 3, 3, 3);
                gridContent.Children.Add(btnRadio);

                //Add text box.
                TextBox txtBox = new TextBox();
                txtBox.Margin = new Thickness(3, 3, 3, 3);
                txtBox.Text = " aksjdlasjdlasjdlkajslkddjasljdlkasjldkjaslkjdalk";
                Grid.SetRow(txtBox, i);
                Grid.SetColumn(txtBox, 1);
                gridContent.Children.Add(txtBox);


            }
        }

        internal void setData(QuestionData data)
        {
            _qdata = data;
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
