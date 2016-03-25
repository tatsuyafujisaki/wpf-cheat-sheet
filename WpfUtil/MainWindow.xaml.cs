using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfUtil
{
    public partial class MainWindow : Window
    {
        public MainWindow(string[] args)
        {
            InitializeComponent();

            Button2.Click += (sender, e) => MessageBox.Show("Hello world!");
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Foo");
        }

        private void DigitOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, @"[^\d]+");
        }

        private void DigitAndDecimalPointOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, @"[^\d.]+");
        }

        private void TrimTextBox(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = tb.Text.Trim();
        }
    }
}
