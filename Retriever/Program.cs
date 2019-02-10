using Fclp;
using System;
using System.Windows.Forms;

namespace Retriever
{
    public class ProgramArgs
    {
        public int RecordId { get; set; }
        public bool Silent { get; set; }
        public string NewValue { get; set; }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)        
        {
            FluentCommandLineParser<ProgramArgs> p = new FluentCommandLineParser<ProgramArgs>();
            p.SetupHelp("h");

            Configuration.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            Configuration.Instance.Save();
        }
    }
}
