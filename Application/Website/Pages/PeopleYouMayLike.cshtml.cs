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
        private readonly UserRecommender _userRecommender;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly ISoftService _softService;
        private readonly IAlcoholService _alcoholService;

        public List<Users> RecommendedUsers { get; private set; }

        // Constructor injection of the UserRecommender
        public PeopleYouMayLikeModel(UserRecommender userRecommender, IUserService userService, IEventService eventService, ISoftService softService, IAlcoholService alcoholService)
        {
            _userRecommender = userRecommender;
            _userService = userService;
            _eventService = eventService;
            _softService = softService;
            _alcoholService = alcoholService;
        }

        public void OnGet()
        {
            Users currentUser = _userService.GetUserById(int.Parse(User.FindFirst("id").Value));
            List<Users> allUsers = _userService.GetAllUsers();
            List<LikedEvent> allEvents = _eventService.GetLikedEvents();
            List<LikedBeverage> allBeverages = _alcoholService.GetLikedBeverages();

            // Use the recommender to find users that the current user may like.
            RecommendedUsers = _userRecommender.RecommendUsers(currentUser, allUsers, allEvents, allBeverages);
        }
    }
}
