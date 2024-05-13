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
        private readonly IPasswordHashingLL _passwordHashingLL;

        public SignUpModel(IUserLL _userLL, IPasswordHashingLL _passwordHashingLL)
        {
            this._userLL = _userLL;
            this._passwordHashingLL = _passwordHashingLL;
        }

        public void OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Index");
            }
        }

        public IActionResult OnPost()
        {
            RegisterDTO.Id = 0;
            RegisterDTO.Role = "customer";
            RegisterDTO.PasswordSalt = _passwordHashingLL.PassSalt(10);
            RegisterDTO.PasswordHash = _passwordHashingLL.PassHash(RegisterDTO.Password, RegisterDTO.PasswordSalt);
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
                RegisterDTO regUser = new RegisterDTO(RegisterDTO.Id,
                                        RegisterDTO.FirstName,
                                        RegisterDTO.LastName,
                                        RegisterDTO.Birthday,
                                        RegisterDTO.Username,
                                        RegisterDTO.Email,
                                        RegisterDTO.PasswordHash,
                                        RegisterDTO.PasswordSalt,
                                        RegisterDTO.PhoneNumber,
                                        RegisterDTO.Role);
                _userLL.CreateUser(regUser);
                return RedirectToPage("/Login");
            }
        }
    }
}
