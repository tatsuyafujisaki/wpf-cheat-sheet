using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace WpfUtil
{
    partial class App : Application
    {
        // Don't use App() constructor for the two reasons.
        // 1. Trying to shut down the application in the constructor makes an error.
        // 2. The following does not work because LoadCompleted needs a form to be triggered.
        // LoadCompleted += (sender, e1) => Shutdown();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CloseDuplicateWithPrompt();

            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();

            if (!AreValidArguments(args))
            {
                MessageBox.Show("Usage: ...");
                Shutdown(1);
                return;
            }

            new MainWindow().Show();
        }

        static void CloseDuplicate()
        {
            var me = Process.GetCurrentProcess();
            foreach (var p in Process.GetProcessesByName(me.ProcessName).Where(p => p.Id != me.Id)) { p.Kill(); }
        }

        void CloseDuplicateWithPrompt()
        {
            var me = Process.GetCurrentProcess();
            var ps = Process.GetProcessesByName(me.ProcessName).Where(p => p.Id != me.Id).ToArray();

            if (!ps.Any()) { return; }

            if (MessageBox.Show("Old processes are running. Close them and proceed?", "", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                foreach (var p in ps) { p.Kill(); }
            }
            else
            {
                Shutdown(1);
            }
        }

        void BringOldToFront()
        {
            var me = Process.GetCurrentProcess();
            var myId = me.Id;

            const int SW_RESTORE = 9;

            foreach (var p in Process.GetProcessesByName(me.ProcessName).Where(p => p.Id != myId))
            {
                NativeMethods.ShowWindow(p.MainWindowHandle, SW_RESTORE);
                NativeMethods.SetForegroundWindow(p.MainWindowHandle);
            }

            Shutdown(1);
        }

        static bool AreValidArguments(string[] args)
        {
            return true;
        }
    }
}