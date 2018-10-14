namespace SuperAwesome.AuthServer.Application.Users
{
    public sealed class Claims
    {
        public Claims(string sub, string role, string name, string email, string[] scopes)
        {
            Sub = sub;
            Role = role;
            Name = name;
            Email = email;
            Scopes = scopes;
        }

        public string Sub { get; }
        public string Role { get; }
        public string Name { get; }
        public string Email { get; }
        public string[] Scopes { get; }
    }
}