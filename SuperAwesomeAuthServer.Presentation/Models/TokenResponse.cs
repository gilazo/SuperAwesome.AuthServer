namespace SuperAwesomeAuthServer.Presentation.Models
{
    public sealed class TokenResponse
    {
        public TokenResponse(Message message)
            : this(message, string.Empty) {}

        public TokenResponse(Token token)
            : this(string.Empty, token) {}

        public TokenResponse(string message, string token)
        {
            Message = message;
            Token = token;
        }

        public string Message { get; }
        public string Token { get; }
    }
}