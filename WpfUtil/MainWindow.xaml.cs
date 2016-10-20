using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfUtil
{
    partial class MainWindow : Window
    {
        internal MainWindow()
        {
            InitializeComponent();

            //if (SomethingWrong)
            //{
            //    // Exit after constructor.
            //    // Note that there is no way to exit in the constructor.
            //    Loaded += (sender, e) => Application.Current.Shutdown(1);
            //}

            Title += U.CreateBreadcrumb();

            DataGrid1.ItemsSource = new List<Record>
            {
                new Record("Name1", false, "User1", DateTime.Now),
                new Record("Name2", false, "User2", DateTime.Now)
            };

            BarButton.Click += (sender, e) => MessageBox.Show("Bar");
        }

        void FooButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Foo");
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

        static void Delete()
        {

        }

        void DataGrid1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Delete();
            }

        }

        void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
