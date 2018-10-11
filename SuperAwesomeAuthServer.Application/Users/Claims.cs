namespace SuperAwesomeAuthServer.Application.Users
{
    public sealed class Claims
    {
        public Claims(string sub, string role, string name)
        {
            Sub = sub;
            Role = role;
            Name = name;
        }

        public string Sub { get; }
        public string Role { get; }
        public string Name { get; }
    }
}