using System.Windows;

namespace WpfCheatSheet
{
    static class MessageBox1
    {
        internal static void Show(string s)
        {
            // MessageBoxOptions.DefaultDesktopOnly is to show a MessageBox topmost.
            MessageBox.Show(s,
                            " ",
                            MessageBoxButton.OK,
                            MessageBoxImage.None,
                            MessageBoxResult.None,
                            MessageBoxOptions.DefaultDesktopOnly);
        }

        // Use OkCancel where clicking Cancel behaves as if you haven't triggered OkCancel.
        internal static bool Ok(string s)
        {
            return MessageBox.Show(s,
                                   " ",
                                   MessageBoxButton.OKCancel,
                                   MessageBoxImage.None,
                                   MessageBoxResult.None,
                                   MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.OK;
        }

        internal static bool Yes(string s)
        {
            return MessageBox.Show(s,
                                   " ",
                                   MessageBoxButton.YesNo,
                                   MessageBoxImage.None,
                                   MessageBoxResult.None,
                                   MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.Yes;
        }
    }
}
