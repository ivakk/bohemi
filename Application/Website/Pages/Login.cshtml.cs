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

namespace Website.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO? LoginDTO { get; set; }

        private readonly IUserLL _userLL;

        public LoginModel(IUserLL _userLL)
        {
            this._userLL = _userLL;
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
                LoginDTO user = _userLL.CheckUser(LoginDTO.Username, LoginDTO.PasswordEntry);
                

                var claims = new List<Claim>
                {
                    new Claim("id", user.Id.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                

                return RedirectToPage("/Index");
            }
            catch (Exception)
            {
                ViewData["Error"] = "Check your login details!";
                return Page();
            }
        }
    }
}
