using Classes;
using InterfacesLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Website.Pages
{
    public class SoftDrinkModel : PageModel
    {
        public Soft? Soft { get; set; }
        public string LikedButtonText => IsSoftLiked ? "Liked ❤" : "Like ❤";
        public bool IsSoftLiked { get; private set; }
        public bool IsLoggedIn { get; set; }

        private readonly ISoftService _softService;
        private readonly IUserService _userService;

        public SoftDrinkModel(ISoftService softService, IUserService _userService)
        {
            _softService = softService;
            this._userService = _userService;
        }
        public void OnGet(int id)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    IsSoftLiked = _softService.IsSoftLiked(new LikedBeverage(int.Parse(User.FindFirst("id").Value), id));
                    IsLoggedIn = true;
                    if (_userService.IsUserBanned(_userService.GetUserById(int.Parse(User.FindFirst("id").Value))))
                    {
                        RedirectToPage("/Logout");
                    }
                }
                Soft = _softService.GetSoftById(id);
            }
            catch (ArgumentNullException)
            {
                Response.Redirect("/404");
            }
            catch (Exception)
            {
                Response.Redirect("/404");
            }
        }
        public IActionResult OnGetImage(int id)
        {
            Soft = _softService.GetSoftById(id);
            if (Soft != null && Soft.Picture != null)
            {
                return File(Soft.Picture, "image/jpeg");
            }
            return NotFound();
        }
        public IActionResult OnPostToggleLiked(int SoftId)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }

            try
            {
                if (User.FindFirst("id") != null)
                {
                    IsSoftLiked = _softService.IsSoftLiked(new LikedBeverage(int.Parse(User.FindFirst("id").Value), SoftId));
                    if (IsSoftLiked)
                    {
                        _softService.RemoveFromLikedSofts(new LikedBeverage(int.Parse(User.FindFirst("id").Value), SoftId));
                    }
                    else
                    {
                        _softService.LikeSoft(new LikedBeverage(int.Parse(User.FindFirst("id").Value), SoftId));
                    }
                    IsSoftLiked = !IsSoftLiked;
                    return RedirectToPage(new { id = SoftId });
                }
                else
                {
                    return RedirectToPage("/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return RedirectToPage(new { id = SoftId });
            }
        }
    }
}
