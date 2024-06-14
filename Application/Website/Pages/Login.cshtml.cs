using Classes;
using InterfacesLL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using DTOs;
using CustomExceptions;

namespace Website.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO? LoginDTO { get; set; }

        private readonly IUserService _userService;

        public LoginModel(IUserService _userService)
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
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }
            
            try
            {
                UserDTO user = _userService.CheckUser(LoginDTO.Username, LoginDTO.PasswordEntry);
                

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, LoginDTO.Username),
                    new Claim("id", user.Id.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                

                return RedirectToPage("/Index");
            }
            catch (BannedException)
            {
                ViewData["Error"] = "You are currently banned!";
                return Page();
            }
            catch (InvalidDataException)
            {
                ViewData["Error"] = "Check your login details!";
                return Page();
            }
            catch(Exception)
            {
                ViewData["Error"] = "Something went wrong";
                return Page();
            }
        }
    }
}
