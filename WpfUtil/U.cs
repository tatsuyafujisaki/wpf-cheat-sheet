using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Control = System.Windows.Forms.Control;
using Screen = System.Windows.Forms.Screen;

namespace WpfUtil
{
    static class U
    {
        static string GetBetween(string s, string from, string to, bool inclusive)
        {
            var pattern = inclusive ? $"({from}.*?{to})" : $"{from}(.*?){to}";
            var m = Regex.Match(s, pattern, RegexOptions.IgnoreCase);
            return m.Success ? m.Groups[1].Value : null;
        }

        internal static string CreateBreadcrumb()
        {
            return $" ({GetBetween(Db.ConnectionString, "data source=", ";", false)} > {GetBetween(Db.ConnectionString, "initial catalog=", ";", false)} > {Db.PackageTable})";
        }

        internal static void Pop(string format, params object[] args)
        {
            MessageBox.Show(string.Format(format, args));
        }

        internal static MessageBoxResult PopOkCancel(string format, params object[] args)
        {
            return MessageBox.Show(string.Format(format, args), "", MessageBoxButton.OKCancel);
        }

        internal static void DragDrop1(DependencyObject dragSource, string path)
        {
            // DoDragDrop needs to be called before the left button is up, not when the left button is up.
            DragDrop.DoDragDrop(dragSource, new DataObject(DataFormats.FileDrop, new[] { path }), DragDropEffects.Copy);
        }

        internal static Screen GetMouseScreen()
        {
            return Screen.FromPoint(Control.MousePosition);
        }

        // An alternative to UIElement.IsMouseOver that is always true.
        internal static bool IsMouseOver2(FrameworkElement fe, MouseEventArgs e)
        {
            var p = e.GetPosition(fe);

            return 0 <= p.X && 0 <= p.Y && p.X <= fe.ActualWidth && p.Y <= fe.ActualHeight;
        }

        internal static IEnumerable<T> GetDataGridItems<T>(DataGrid dg)
        {
            return dg.Items.Cast<T>();
        }
    }
}