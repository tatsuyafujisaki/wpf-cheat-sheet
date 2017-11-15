using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WpfCheatSheet.Behaviors
{
    // This behavior is exclusive to Window hence Behavior<Window> is used rather than Behavior<UIElement>.
    // This behavior does not need VM hence does not create ICommand, which is a way of accessing VM.
    public sealed class EscapeOnWindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.KeyDown += Callback;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyDown -= Callback;
        }

        static void Callback(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Escape)
            {
                return;
            }

            ((Window)sender).Close();
            e.Handled = true;
        }
    }
}