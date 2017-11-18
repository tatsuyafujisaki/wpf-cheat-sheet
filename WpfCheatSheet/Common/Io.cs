using Microsoft.Win32;
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
            // You may want to set the RestoreDirectory property true but the property is not implemented.
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.win32.filedialog.restoredirectory
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

        internal static string GetUnc(string path)
        {
            string GetUnc(char driveLetter)
            {
                using (var rk = Registry.CurrentUser.OpenSubKey(@"Network\" + driveLetter))
                {
                    return rk?.GetValue("RemotePath").ToString();
                }
            }

            // Remove enclosing double quotation marks if they exist.
            path = path.Replace("\"", "");

            // Do nothing if a given path is relative or already UNC.
            if (!Path.IsPathRooted(path) || path.StartsWith(@"\\"))
            {
                return path;
            }

            switch (path.Length)
            {
                case 1:
                    return char.IsLetter(path[0]) ? (GetUnc(path[0]) ?? path) : path;
                case 2:
                    return char.IsLetter(path[0]) && path[1] == ':' ? (GetUnc(path[0]) ?? path) : path;
                default:
                    if (char.IsLetter(path[0]) && path[1] == ':' && path[2] == '\\')
                    {
                        var unc = GetUnc(path[0]);
                        return unc != null ? Path.Combine(unc, path.Substring(3)) : path;
                    }
                    else
                    {
                        return null;
                    }
            }
        }
    }
}
