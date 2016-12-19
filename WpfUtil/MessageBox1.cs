using System;

namespace WpfUtil
{
    static class MessageBox1
    {
        // Show a window topmost
        const uint MbServiceNotification = 0x00200000;

        internal static void Show(string s)
        {
            NativeMethods.MessageBox(IntPtr.Zero, s, " ", MbServiceNotification);
        }

        // Use OkCancel where clicking Cancel behaves as if you haven't triggered OkCancel.
        internal static bool Ok(string s)
        {
            const uint mbOkCancel = 0x00000001;
            const int idOk = 1;

            return NativeMethods.MessageBox(IntPtr.Zero, s, " ", MbServiceNotification | mbOkCancel) == idOk;
        }

        internal static bool Yes(string s)
        {
            const uint mbYesNo = 0x00000004;
            const int idYes = 6;

            return NativeMethods.MessageBox(IntPtr.Zero, s, " ", MbServiceNotification | mbYesNo) == idYes;
        }
    }
}
