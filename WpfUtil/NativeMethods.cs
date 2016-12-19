using System;
using System.Runtime.InteropServices;

namespace WpfUtil
{
    static class NativeMethods
    {
        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms645505.aspx
        // "CharSet = CharSet.Unicode" is to avoid the warning CA2101.
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms633539.aspx
        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms633548.aspx
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}