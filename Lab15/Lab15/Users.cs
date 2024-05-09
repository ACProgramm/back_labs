using System.Collections.Generic;


namespace Lab15
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>()
        {
            new Users { Username = "admin", Password = "admin", Role = "Admin" },
            new Users { Username = "user", Password = "user", Role = "User" }
        };
        }
    }
}

