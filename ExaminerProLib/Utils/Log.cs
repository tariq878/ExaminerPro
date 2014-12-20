using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.Utils
{
    public class Log
    {

        private static Log singleton;
        private StreamWriter logWriter;
        private string filePath = "";
        public static Log Instance
        {
            get { return singleton ?? (singleton = new Log()); }
        }

        public Log()
        {
            filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "Log.txt";
            Open(true);

        }

        public void Open(bool append)
        {
            if (logWriter != null)
                throw new InvalidOperationException(
                    "Logger is already open");

            logWriter = new StreamWriter(filePath, append);
            logWriter.AutoFlush = true;
        }

        public void Close()
        {
            if (logWriter != null)
            {
                logWriter.Close();
                logWriter = null;
            }
        }

        public void LogException(Exception ex)
        {
            String exc = ex.Message + "\n" + ex.StackTrace;
            CreateEntry(exc);
            Console.WriteLine(exc);

        }

        public void CreateEntry(string entry)
        {
            Console.WriteLine("Wrinting to " + filePath);
            if (this.logWriter == null)
                throw new InvalidOperationException(
                    "Logger is not open");
            logWriter.WriteLine("{0} - {1}",
                 DateTime.Now.ToString("ddMMyyyy hh:mm:ss"),
                 entry);
        }
    }
}
