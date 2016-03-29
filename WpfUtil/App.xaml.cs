using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace WpfUtil
{
    public partial class App : Application
    {
        public App()
        {
            // BringOldToFront();
            CloseDuplicate();

            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();

            if (!AreValidArguments(args))
            {
                LoadCompleted += (sender, e) => Current.Shutdown();
                return;
            }

            // InitializeComponent() is necessary to enable <Application.Resource> in App.xaml.
            InitializeComponent();

            var p = System.Windows.Forms.Control.MousePosition;

            new MainWindow(Environment.GetCommandLineArgs().Skip(1).ToArray())
            {
                Left = p.X,
                Top = p.Y
            }.Show();
        }

        private static void CloseDuplicate()
        {
            var me = Process.GetCurrentProcess();
            foreach (var p in Process.GetProcessesByName(me.ProcessName).Where(p => p.Id != me.Id)) { p.Kill(); }
        }

        private static void BringOldToFront()
        {
            var me = Process.GetCurrentProcess();
            var myId = me.Id;

            const int SW_RESTORE = 9;

            foreach (var p in Process.GetProcessesByName(me.ProcessName).Where(p => p.Id != myId))
            {
                NativeMethods.ShowWindow(p.MainWindowHandle, SW_RESTORE);
                NativeMethods.SetForegroundWindow(p.MainWindowHandle);
            }

            Current.Shutdown();
        }

        private static bool AreValidArguments(string[] args)
        {
            return true;
        }
    }
}