namespace SuperAwesome.AuthServer.Application
{
    public sealed class Secret
    {
        public Secret(string secret)
        {
            Value = secret;
        }

        public string Value { get; }
    }
}
