namespace SuperAwesomeAuthServer.Presentation.Models
{
    public sealed class TokenRequest
    {
        public TokenHeader Header { get; set; }
        public object Payload { get; set; }
    }
}