using Classes;
using DTOs;
using InterfacesLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Website.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Username should be between 3 and 16 letters and numbers!")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid username!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required!")]
        public string? Username { get; set; }

        [BindProperty]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 32 symbols!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
        public string? Password { get; set; }

        [BindProperty]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Passwords should match!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
        public string? ConfirmPassword { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email field is required!")]
        public string? Email { get; set; }

        [BindProperty]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid first name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
        public string? FirstName { get; set; }

        [BindProperty]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid last name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
        public string? LastName { get; set; }

        [BindProperty]
        [RegularExpression(@"^\+?(\d{1,3})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,9})$", ErrorMessage = "Please enter a valid phone number!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number field is required!")]
        public string? PhoneNumber { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Birthdate field is required!")]
        public DateTime? Birthdate { get; set; }

        private readonly IUserLL _userLL;
        private readonly _PasswordHashingLL _passwordHashingLL;
        string passwordSalt;
        string passwordHash;

        public SignUpModel(IUserLL _userLL, _PasswordHashingLL _passwordHashingLL)
        {
            this._userLL = _userLL;
            this._passwordHashingLL = _passwordHashingLL;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }

            if (Password != ConfirmPassword)
            {
                ViewData["Error"] = "Passwords don't match!";
                return Page();
            }
            else
            {
                DateTime birthdate = Birthdate.Value;
                passwordSalt = _passwordHashingLL.PassSalt(10);
                passwordHash = _passwordHashingLL.PassHash(Password, passwordSalt);
                RegisterDTO regUser = new RegisterDTO(
                                        FirstName,
                                        LastName,
                                        birthdate,
                                        Username,
                                        Email,
                                        passwordHash,
                                        passwordSalt,
                                        PhoneNumber,
                                        "customer");
                _userLL.CreateUser(regUser);
                return RedirectToPage("/Login");
            }
        }
    }
}
