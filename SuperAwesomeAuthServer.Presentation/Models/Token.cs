namespace SuperAwesomeAuthServer.Presentation.Models
{
    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static implicit operator string(Token message)
        {
            return message.Value;
        }

        public static implicit operator Token(string value)
        {
            return new Token(value);
        }
    }
}