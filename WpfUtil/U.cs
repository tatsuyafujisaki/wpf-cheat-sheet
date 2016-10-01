using System.Windows;
using System.Windows.Input;
using Control = System.Windows.Forms.Control;
using Screen = System.Windows.Forms.Screen;

namespace WpfUtil
{
    static class U
    {
        static Screen GetMouseScreen()
        {
            return Screen.FromPoint(Control.MousePosition);
        }

        // An alternative to UIElement.IsMouseOver that is always true.
        static bool IsMouseOver2(FrameworkElement fe, MouseEventArgs e)
        {
            var p = e.GetPosition(fe);

            return 0 <= p.X && 0 <= p.Y && p.X <= fe.ActualWidth && p.Y <= fe.ActualHeight;
        }
    }
}