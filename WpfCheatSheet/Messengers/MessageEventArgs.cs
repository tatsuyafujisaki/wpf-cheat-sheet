using System;

namespace WpfCheatSheet.Messengers
{
    public sealed class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(Message message)
        {
            Message = message;
        }

        public Message Message { get; private set; }
    }
}