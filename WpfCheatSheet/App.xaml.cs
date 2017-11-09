using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using WpfCheatSheet.Views;

namespace WpfCheatSheet
{
    partial class App : Application
    {
        // Don't use App() constructor for the two reasons.
        // 1. Trying to shut down the application in the constructor makes an error.
        // 2. The following does not work because LoadCompleted needs a form to be triggered.
        protected override void OnStartup(StartupEventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.CheckForUpdate() && ApplicationDeployment.CurrentDeployment.Update())
            {
                Process.Start(ApplicationDeployment.CurrentDeployment.UpdateLocation.AbsoluteUri);
                Shutdown(1);
            }

            if (DateTime.Today.Day % 2 == 0)
            {
                MessageBox.Show("Usage: ...");
                Shutdown(1);
                return;
            }

            new MainWindow().Show();
        }

        void BringOldToFront()
        {
            var me = Process.GetCurrentProcess();

            const int SW_RESTORE = 9;

            foreach (var p in Process.GetProcessesByName(me.ProcessName).Where(p => p.Id != me.Id))
            {
                NativeMethods.ShowWindow(p.MainWindowHandle, SW_RESTORE);
                NativeMethods.SetForegroundWindow(p.MainWindowHandle);
            }

            Shutdown(1);
        }
    }
}