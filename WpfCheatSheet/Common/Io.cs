using System;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace WpfCheatSheet
{
    class Io
    {
        // Mark Main method with STAThread or the dialog will not appear.
        internal static string FolderBrowserDialog()
        {
            var fbd = new FolderBrowserDialog
            {
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            return fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : null;
        }

        // Mark Main method with STAThread or the dialog will not appear.
        internal static string OpenFileDialog()
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            return ofd.ShowDialog() == true ? ofd.FileName : null;
        }

        // Mark Main method with STAThread or the dialog will not appear.
        internal static string SaveFileDialog()
        {
            var sfd = new SaveFileDialog
            {
                Filter = @"All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            return sfd.ShowDialog() == true ? sfd.FileName : null;
        }
    }
}
