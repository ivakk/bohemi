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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password field is required!")]
        public string PasswordEntry { get; set; }

        public LoginDTO(string username, string passwordEntry)
        {
            Username = username;
            PasswordEntry = passwordEntry;
        }
        
        public LoginDTO() 
        { 
        }
    }
}
