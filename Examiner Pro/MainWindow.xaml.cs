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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Examiner_Pro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void runWizardButton_Click(object sender, RoutedEventArgs e)
        {
            WizardDialogBox wizard = new WizardDialogBox();
            bool dialogResult = (bool)wizard.ShowDialog();
            if (dialogResult)
            {
                MessageBox.Show(string.Format("{0}\n{1}\n{2}", wizard.WizardData.DataItem1, wizard.WizardData.DataItem2, wizard.WizardData.DataItem3));
            }
            else
            {
                MessageBox.Show("Canceled.");
            }
        }
    }
}
