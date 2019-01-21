using System;
using System.Windows.Forms;

namespace Retriever
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Configuration.Load();
            Application.Run(new FormMain());
            Configuration.Instance.Save();
        }
    }
}
