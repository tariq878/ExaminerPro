using Examiner_Pro.Examiner.GUI;
using Examiner_Pro.Examiner;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ExaminerProLib.Utils;
using Examiner_Pro.Examiner.GUI.Exams.AddWizard;
using Examiner_Pro.Examiner.GUI.Exams;

namespace Examiner_Pro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public  void ApplicationStart(object sender, StartupEventArgs e)
        {
            Log.Instance.CreateEntry("----------------------------------------------");
            Log.Instance.CreateEntry("Application Starting.");
            //Disable shutdown when the dialog closes
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            //var dialog = new LoginWindow();
            //AddQuestion1 dialog = new AddQuestion1();
            ExamQuestions dialog = new ExamQuestions();
                if (dialog.ShowDialog() == true)
            {
                Log.Instance.CreateEntry("User Logged In.");
                var mainWindow = new Main();
                //Re-enable normal shutdown mode.
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = mainWindow;
                mainWindow.Show();
            }
            else
            {
                Log.Instance.CreateEntry("Cancel pressed on login window. Exiting program.");
                Current.Shutdown(-1);
            }
        }
    }
}
