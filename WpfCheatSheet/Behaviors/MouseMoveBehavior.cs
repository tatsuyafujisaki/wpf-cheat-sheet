using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WpfCheatSheet.Behaviors
{
    public sealed class MouseMoveBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += Callback;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= Callback;
        }

        void Callback(object sender, MouseEventArgs e)
        {
            ((ICommand)GetValue(Dp)).Execute(e);
            e.Handled = true;
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(Dp);
            set => SetValue(Dp, value);
        }

        static readonly DependencyProperty Dp = DependencyProperty.Register("Command", typeof(ICommand), typeof(MouseMoveBehavior));
    }
}