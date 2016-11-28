using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

            SetIcon();

            // Set MaxHeight to enable a vertical scrollbar.
            DataGrid1.MaxHeight = SystemParameters.VirtualScreenHeight * 0.8;

            Title += U.CreateBreadcrumb();

            DataGrid1.ItemsSource = new List<Record>
            {
                new Record("Name1", false, "User1", DateTime.Now),
                new Record("Name2", false, "User2", DateTime.Now)
            };

            BarButton.Click += (sender, e) => MessageBox.Show("Bar");
        }

        // http://glyphicons.com
        // To use the resource image Foo.ico by "Resources/Foo.ico" instead of "var x = Properties.Resources.Foo",
        // change the properties of the image as follows.
        // * Build Action -> Content
        // * Copy to Output Directory -> Copy if newer
        void SetIcon()
        {
            string uri;

            switch (ConfigurationManager.AppSettings["Environment"])
            {
                case "p":
                    uri = "Resources/Flag.ico";
                    break;
                case "1":
                    uri = "Resources/Tortoise.ico";
                    break;
                case "2":
                    uri = "Resources/Rabbit.ico";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Icon = new BitmapImage(new Uri(uri, UriKind.Relative));
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
