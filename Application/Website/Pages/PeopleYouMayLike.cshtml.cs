using Classes;
using InterfacesLL;
using LogicLayer.RecommendationStrategy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    [Authorize]
    public class PeopleYouMayLikeModel : PageModel
    {
        [BindProperty]
        public List<Users>? RecommendedUsers { get; set; }

        private readonly UserRecommender _userRecommender;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly IAlcoholService _alcoholService;

        public PeopleYouMayLikeModel(UserRecommender userRecommender, IUserService userService, IEventService eventService, IAlcoholService alcoholService)
        {
            _userRecommender = userRecommender;
            _userService = userService;
            _eventService = eventService;
            _alcoholService = alcoholService;
        }

        public void OnGet()
        {
            if (_userService.IsUserBanned(_userService.GetUserById(int.Parse(User.FindFirst("id").Value))))
            {
                RedirectToPage("/Logout");
            }

            Users currentUser = _userService.GetUserById(int.Parse(User.FindFirst("id").Value));
            List<Users> allUsers = _userService.GetAllUsers();
            List<LikedEvent> allEvents = _eventService.GetLikedEvents();
            List<LikedBeverage> allBeverages = _alcoholService.GetLikedBeverages();

            // Use the recommender to find users that the current user may like.
            RecommendedUsers = _userRecommender.RecommendUsers(currentUser, allUsers, allEvents, allBeverages);
        }
        public IActionResult OnGetImage(int id)
        {
            var e = _userService.GetUserById(id);
            if (e != null && e.ProfilePicture != null)
            {
                return File(e.ProfilePicture, "image/jpeg");
            }
            return NotFound();
        }
    }
}
