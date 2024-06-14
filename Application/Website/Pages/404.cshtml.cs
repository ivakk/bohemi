using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class _404Model : PageModel
    {
        public bool IsLoggedIn { get; set; }
        public void OnGet()
        {
            //Checks whether there is a user currently logged in
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
            }
        }
    }
}
