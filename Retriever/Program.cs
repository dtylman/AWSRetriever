using Fclp;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Retriever
{
    public static class NativeMethods
    {
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }

    public class ProgramArgs
    {
        public string ConfigFile { get; set; }
        public bool RunNow { get; set; }
        public string ProfileFile { get; set; }
        public string OutFile { get; set; }
    }

    static class Program
    {
        public static bool TryAttachConsole()
        {
            try
            {
                IntPtr ptr = NativeMethods.GetForegroundWindow();
                NativeMethods.GetWindowThreadProcessId(ptr, out int u);
                Process process = Process.GetProcessById(u);
                return NativeMethods.AttachConsole(process.Id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool consoleAttached = TryAttachConsole();
            try
            {
                AppMain(consoleAttached);
            }
            finally
            {
                if (consoleAttached)
                {
                    NativeMethods.FreeConsole();
                }
            }

        }

        private static void AppMain(bool consoleAttached)
        {
            if (consoleAttached)
            {
                Console.WriteLine("AWS Retriver");
            }
            FluentCommandLineParser<ProgramArgs> p = new FluentCommandLineParser<ProgramArgs>();
            p.Setup(arg => arg.RunNow).As('r', "run").SetDefault(false).WithDescription("Run now");
            p.Setup(arg => arg.ConfigFile).As('c', "config").SetDefault(Configuration.DefaultFileName).WithDescription("Specify configuration file");
            p.Setup(arg => arg.ProfileFile).As('p', "profile").WithDescription("Profile to run");
            p.Setup(arg => arg.OutFile).As('o', "output").WithDescription("Output file").SetDefault("retriver.objects.json");
            p.SetupHelp("h", "help").Callback(text =>
                {
                    Console.WriteLine("Usage:");
                    Console.WriteLine(text);
                });
            var result = p.Parse(Environment.GetCommandLineArgs());
            if (result.HasErrors)
            {
                Console.WriteLine(result.ErrorText);
                return;
            }
            if (result.HelpCalled)
            {
                return;
            }
            Configuration.Load(p.Object.ConfigFile);
            if (p.Object.RunNow)
            {
                ConsoleScanner cs = new ConsoleScanner();
                cs.Scan(p.Object.OutFile);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                Configuration.Instance.Save();
            }

        }

    }
}
