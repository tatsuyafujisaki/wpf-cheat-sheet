using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCheatSheet.Views
{
    sealed partial class MainWindow : Window
    {
        internal MainWindow()
        {
            InitializeComponent();
        }

        void DigitOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);
        }

        void DigitOrOneDecimalPointOnly(object sender, TextCompositionEventArgs e)
        {
            var tb = (TextBox)sender;
            var c = e.Text[0];

            e.Handled = tb.Text.Count(x => x == '.') + (c == '.' ? 1 : 0) > 1
                        || !(char.IsDigit(c) || c == '.');
        }

        void TrimTextBox(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = tb.Text.Trim();
        }
    }
}
