using Classes;
using InterfacesLL;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;

namespace Website.Pages
{
    public class AlcoholModel : PageModel
    {
        public Alcohol? Alcohol { get; set; }
        public string LikedButtonText => IsAlcoholLiked ? "Liked ❤" : "Like ❤";
        public bool IsAlcoholLiked { get; private set; }
        public bool IsLoggedIn { get; set; }

        private readonly IAlcoholService _alcoholService;
        private readonly IUserService _userService;

        public AlcoholModel(IAlcoholService alcoholService, IUserService _userService)
        {
            _alcoholService = alcoholService;
            this._userService = _userService;
        }
        public void OnGet(int id)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    IsAlcoholLiked = _alcoholService.IsAlcoholLiked(new LikedBeverage(int.Parse(User.FindFirst("id").Value), id));
                    IsLoggedIn = true;
                    if (_userService.IsUserBanned(_userService.GetUserById(int.Parse(User.FindFirst("id").Value))))
                    {
                        RedirectToPage("/Logout");
                    }
                }
                Alcohol = _alcoholService.GetAlcoholById(id);
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
            Alcohol = _alcoholService.GetAlcoholById(id);
            if (Alcohol != null && Alcohol.Picture != null)
            {
                return File(Alcohol.Picture, "image/jpeg");
            }
            return NotFound();
        }
        public IActionResult OnPostToggleLiked(int alcoholId)
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
                    IsAlcoholLiked = _alcoholService.IsAlcoholLiked(new LikedBeverage(int.Parse(User.FindFirst("id").Value), alcoholId));
                    if (IsAlcoholLiked)
                    {
                        _alcoholService.RemoveFromLikedAlcohols(new LikedBeverage(int.Parse(User.FindFirst("id").Value), alcoholId));
                    }
                    else
                    {
                        _alcoholService.LikeAlcohol(new LikedBeverage(int.Parse(User.FindFirst("id").Value), alcoholId));
                    }
                    IsAlcoholLiked = !IsAlcoholLiked;
                    return RedirectToPage(new { id = alcoholId });
                }
                else
                {
                    return RedirectToPage("/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return RedirectToPage(new { id = alcoholId });
            }
        }
    }
}
