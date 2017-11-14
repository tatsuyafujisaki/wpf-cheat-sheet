using System.Windows;
using System.Windows.Interactivity;

namespace WpfCheatSheet.Messengers
{
    public sealed class MessageTriggerAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            MessageBox.Show(((MessageEventArgs)parameter).Message.Body);
        }
    }
}
