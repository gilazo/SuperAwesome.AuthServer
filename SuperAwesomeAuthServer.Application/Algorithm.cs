namespace SuperAwesomeAuthServer.Application
{
    public class Algorithm
    {
        public Algorithm(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static implicit operator string(Algorithm message)
        {
            return message.Value;
        }

        public static implicit operator Algorithm(string value)
        {
            return new Algorithm(value);
        }
    }
}
