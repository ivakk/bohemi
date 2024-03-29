using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LoginDTO
    {
        public int Id { get; }
        public string Username { get; set; }
        public string PasswordEntry { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }

        public LoginDTO(int id, string username, string passwordEntry, string passwordHash, string passwordSalt, string role)
        {
            Id = id;
            Username = username;
            PasswordEntry = passwordEntry;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Role = role;
        }
        
        public LoginDTO() 
        { 
        }
    }
}
