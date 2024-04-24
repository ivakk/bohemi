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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid last name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Birthdate field is required!")]
        public DateTime Birthday { get; set; }

        [StringLength(16, MinimumLength = 3, ErrorMessage = "Username should be between 3 and 16 letters and numbers!")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid username!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required!")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email field is required!")]
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        [RegularExpression(@"^\+?(\d{1,3})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,9})$", ErrorMessage = "Please enter a valid phone number!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number field is required!")]
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public UpdateUserDTO(int id, byte[] profilePicture, string firstName, string lastName, DateTime birthday, string username, string email, string passwordHash, string passwordSalt, string phoneNumber, string role)
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
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public UpdateUserDTO()
        {
        }
    }
}
