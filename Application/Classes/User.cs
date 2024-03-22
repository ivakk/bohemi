using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        public int Id { get; }
        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }

        public User(int id, byte[] profilePicture, string firstName, string lastName, DateTime birthday, string username, string email, string passwordHash, string passwordSalt, string role)
        {
            Id = id;
            ProfilePicture = profilePicture;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Role = role;
        }
        
        public User() 
        {

        }
    }
}
