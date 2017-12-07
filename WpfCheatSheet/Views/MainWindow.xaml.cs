using System.Windows;
using System.Windows.Input;

namespace WpfCheatSheet.Views
{
    sealed partial class MainWindow : Window
    {
        internal MainWindow()
        {
            InitializeComponent();
        }

        private void CheckIfNewPackageAvailable(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("New version is available. Restart?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                // Start the new version and close self.
            }

            e.Handled = true;
        }
    }
}
