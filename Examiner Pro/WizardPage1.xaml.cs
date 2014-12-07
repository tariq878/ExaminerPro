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
    /// Interaction logic for WizardPage1.xaml
    /// </summary>
    public partial class WizardPage1 : PageFunction<WizardResult>
    {
        public WizardPage1(WizardData wizardData)
        {
            InitializeComponent();

            // Bind wizard state to UI
            this.DataContext = wizardData;
        }

        void nextButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to next wizard page
            WizardPage2 wizardPage2 = new WizardPage2((WizardData)this.DataContext);
            wizardPage2.Return += new ReturnEventHandler<WizardResult>(wizardPage_Return);
            this.NavigationService.Navigate(wizardPage2);
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel the wizard and don't return any data
            OnReturn(new ReturnEventArgs<WizardResult>(WizardResult.Canceled));
        }

        public void wizardPage_Return(object sender, ReturnEventArgs<WizardResult> e)
        {
            // If returning, wizard was completed (finished or canceled),
            // so continue returning to calling page
            OnReturn(e);
        }
    }
}
