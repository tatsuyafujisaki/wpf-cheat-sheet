using System;

namespace WpfCheatSheet.Messengers
{
    public sealed class Messenger
    {
        public event EventHandler<MessageEventArgs> Sent;

        public void Send(Message message)
        {
            Sent?.Invoke(this, new MessageEventArgs(message));
        }
    }
}