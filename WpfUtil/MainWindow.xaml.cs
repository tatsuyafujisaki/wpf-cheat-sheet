using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfUtil
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //if (SomethingBadHappend)
            //{
            //    // Exit after constructor.
            //    // Note that there is no way to quit in the constructor.
            //    Loaded += (sender, e) => Application.Current.Shutdown(1);
            //}

            Button2.Click += (sender, e) => MessageBox.Show("Hello world!");
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Foo");
        }

        private void DigitOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]);
        }

        private void DigitOrOneDecimalPointOnly(object sender, TextCompositionEventArgs e)
        {
            var tb = (TextBox)sender;
            var c = e.Text[0];

            e.Handled = tb.Text.Count(x => x == '.') + (c == '.' ? 1 : 0) > 1
                        || !(char.IsDigit(c) || c == '.');
        }

        private void TrimTextBox(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = tb.Text.Trim();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}