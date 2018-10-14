using SuperAwesome.AuthServer.Application.Users;

namespace SuperAwesome.AuthServer.Presentation.WebApi.Models
{
    public sealed class UsersTokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User ToUser()
        {
            return new User(Username, Password);
        }
    }
}