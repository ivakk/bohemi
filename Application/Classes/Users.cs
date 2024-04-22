using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Users
    {
        public int Id { get; }
        public byte[]? ProfilePicture { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Role { get; private set; }

        public Users(int id, byte[]? profilePicture, string firstName, string lastName, DateTime birthday, string username, string email, string phoneNumber,  string role)
        {
            Id = id;
            ProfilePicture = profilePicture;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Username = username;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public Users() 
        {

        }
    }
}
