using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }

        public byte[] ProfilePicture { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid first name!")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid last name!")]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [StringLength(16, MinimumLength = 3, ErrorMessage = "Username should be between 3 and 16 letters and numbers!")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid username!")]
        public string? Username { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        public string? Email { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        [RegularExpression(@"^\+?(\d{1,3})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,9})$", ErrorMessage = "Please enter a valid phone number!")]
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 32 symbols!")]
        public string? Password { get; set; }

        [StringLength(32, MinimumLength = 8, ErrorMessage = "Passwords should match!")]
        public string? ConfirmPassword { get; set; }

        public UpdateUserDTO(int id, byte[] profilePicture, string firstName, string lastName, DateTime birthday, string username, string email, string password, string phoneNumber, string role)
        {
            Id = id;
            ProfilePicture = profilePicture;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Username = username;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public UpdateUserDTO()
        {
        }

        public string GetObjectString()
        {
            return Id.ToString() + " " + Username + " " + FirstName + " " + LastName + " " + Email + " " + Role + " " + Birthday.ToString() + " " + PhoneNumber;
        }
    }
}
