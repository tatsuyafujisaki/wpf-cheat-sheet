namespace WpfCheatSheet.Messengers
{
    public sealed class Message
    {
        public Message(string body)
        {
            Body = body;
        }

        public string Body { get; private set; }
    }
}
