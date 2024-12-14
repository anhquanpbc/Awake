using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Awake
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (IsApplicationAlreadyRunning())
            {
                MessageBox.Show("The application is already running.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Shutdown();
            }
        }

        private bool IsApplicationAlreadyRunning()
        {
            var currentProcess = Process.GetCurrentProcess();
            var runningProcesses = Process.GetProcessesByName(currentProcess.ProcessName);

            return runningProcesses.Any(p => p.Id != currentProcess.Id);
        }
    }
}
