namespace SuperAwesome.AuthServer.Application.Users
{
    public sealed class User
    {
        public User(string email, string password)
            : this(string.Empty, string.Empty, email, password, new string[] { }) { }

        public User(string firstName, string lastName, string email, string password, string[] scopes)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Scopes = scopes;
        }
        
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string[] Scopes { get; }

        public string Name => $"{FirstName} {LastName}";
    }
}
