using System.Windows;

namespace WpfUtil
{
    static class MessageBox1
    {
        // MessageBoxOptions.DefaultDesktopOnly is to bring a MessageBox to the front.
        internal static void Show(string s)
        {
            MessageBox.Show(s,
                            " ",
                            MessageBoxButton.OK,
                            MessageBoxImage.None,
                            MessageBoxResult.None,
                            MessageBoxOptions.DefaultDesktopOnly);
        }

        // Use YesNo when clicking No doesn't behaves as if you didn't trigger YesNo.
        internal static bool Yes(string s)
        {
            return MessageBox.Show(s,
                                   " ",
                                   MessageBoxButton.YesNo,
                                   MessageBoxImage.None,
                                   MessageBoxResult.None,
                                   MessageBoxOptions.DefaultDesktopOnly)
                                   == MessageBoxResult.Yes;
        }

        // Use OkCancel when clicking Cancel behaves as if you didn't trigger OkCancel.
        internal static bool Ok(string s)
        {
            return MessageBox.Show(s,
                                   " ",
                                   MessageBoxButton.OKCancel,
                                   MessageBoxImage.None,
                                   MessageBoxResult.None,
                                   MessageBoxOptions.DefaultDesktopOnly)
                                   == MessageBoxResult.OK;
        }
    }
}
