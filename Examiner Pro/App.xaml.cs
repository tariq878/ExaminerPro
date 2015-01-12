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
using Examiner_Pro.Examiner.GUI.Question;
using Examiner_Pro.Examiner.GUI.Exams;
using Examiner_Pro.Examiner.GUI.Student;

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
            //QuestionAdd dialog = new QuestionAdd();
            //QuestionManage dialog = new QuestionManage();
            //Main dialog = new Main();
            //ExamManage dialog = new ExamManage();
            var dialog = new ExamAssignManage();

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
