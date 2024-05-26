using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LoginDTO
    {
        public int Id { get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password field is required!")]
        public string PasswordEntry { get; set; }
        public string? Role { get; set; }

        public LoginDTO(int id, string username, string passwordEntry, string role)
        {
            Id = id;
            Username = username;
            PasswordEntry = passwordEntry;
            Role = role;
        }
        
        public LoginDTO() 
        { 
        }
    }
}
