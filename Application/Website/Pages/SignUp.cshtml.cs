using Classes;
using CustomExceptions;
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

        private readonly IUserService _userService;

        public SignUpModel(IUserService _userService)
        {
            this._userService = _userService;
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

            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";

                return Page();
            }

            try
            {
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
                                            RegisterDTO.Password,
                                            RegisterDTO.PhoneNumber,
                                            RegisterDTO.Role);

                    bool success = _userService.CreateUser(regUser);

                    if(success)
                    {
                        return RedirectToPage("/Login");
                    }
                    else
                    {
                        return Page();
                    }
                }
            }
            catch (UsernameUsedException)
            {
                ViewData["Error"] = "Username is already in use!";
                return Page();
            }
            catch (EmailUsedException)
            {
                ViewData["Error"] = "Email address is already in use!";
                return Page();
            }
            catch (Exception)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }
        }
    }
}
