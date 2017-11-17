using System;
using System.IO;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace WpfCheatSheet
{
    class Io
    {
        // Mark Main method with STAThread or the dialog will not appear.
        internal static string FolderBrowserDialog(string selectedPath = null)
        {
            var fbd = new FolderBrowserDialog
            {
                SelectedPath = Directory.Exists(selectedPath)
                               ? selectedPath
                               : Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            return fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : null;
        }

        // Mark Main method with STAThread or the dialog will not appear.
        internal static string OpenFileDialog(string initialDirectory = null)
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Directory.Exists(initialDirectory)
                                   ? initialDirectory
                                   : Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
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
