namespace SuperAwesomeAuthServer.Presentation.Models
{
    public sealed class Message
    {
        public Message(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static implicit operator string(Message message)
        {
            return message.Value;
        }

        public static implicit operator Message(string value)
        {
            return new Message(value);
        }
    }
}