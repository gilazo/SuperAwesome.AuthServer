namespace SuperAwesomeAuthServer.Presentation.Models
{
    public sealed class UsersTokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}