using Examiner_Pro.Examiner.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Examiner_Pro
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        private Timer t;
        LoginWindow m;
        public Splash()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m = new LoginWindow(); // Creates but wont show

            t = new Timer(new TimerCallback(CloseSplash), null, new TimeSpan(0, 0, 3), new TimeSpan(0, 0, 0, 0, -1));

        }

        private void CloseSplash(object info)
        {
            this.Dispatcher.Invoke((Action)(() => { m.Show(); Close(); }));
        }

    }
}
