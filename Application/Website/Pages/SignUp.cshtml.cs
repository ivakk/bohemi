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
        public RegisterDTO RegisterDTO { get; set; }

        private readonly IUserLL _userLL;
        private readonly _PasswordHashingLL _passwordHashingLL;

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

            if (RegisterDTO.Password != RegisterDTO.ConfirmPassword)
            {
                ViewData["Error"] = "Passwords don't match!";
                return Page();
            }
            else
            {
                RegisterDTO.PasswordSalt = _passwordHashingLL.PassSalt(10);
                RegisterDTO.PasswordHash = _passwordHashingLL.PassHash(RegisterDTO.Password, RegisterDTO.PasswordSalt);
                RegisterDTO regUser = new RegisterDTO(
                                        RegisterDTO.FirstName,
                                        RegisterDTO.LastName,
                                        RegisterDTO.Birthday,
                                        RegisterDTO.Username,
                                        RegisterDTO.Email,
                                        RegisterDTO.PasswordHash,
                                        RegisterDTO.PasswordSalt,
                                        RegisterDTO.PhoneNumber,
                                        "customer");
                _userLL.CreateUser(regUser);
                return RedirectToPage("/Login");
            }
        }
    }
}
