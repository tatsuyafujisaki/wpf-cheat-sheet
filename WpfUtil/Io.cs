using Microsoft.Win32;
using System;

namespace WpfUtil
{
    class Io
    {
        // Mark Main method with STAThread or the dialog will not appear.
        static string OpenFileDialog()
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            return ofd.ShowDialog() == true ? ofd.FileName : null;
        }

        // Mark Main method with STAThread or the dialog will not appear.
        static string SaveFileDialog()
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
