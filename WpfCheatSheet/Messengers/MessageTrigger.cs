using System.Windows.Interactivity;

namespace WpfCheatSheet.Messengers
{
    public sealed class MessageTrigger : EventTrigger
    {
        protected override string GetEventName()
        {
            return "Sent";
        }
    }
}
