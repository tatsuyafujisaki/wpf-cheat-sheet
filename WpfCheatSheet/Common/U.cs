using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCheatSheet.Common
{
    static class U
    {
        internal static string CreateBreadcrumb()
        {
            return $" ({Db.Sccb.DataSource} > {Db.Sccb.InitialCatalog} > {Db.Table})";
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