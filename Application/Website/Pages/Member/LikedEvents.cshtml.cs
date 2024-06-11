using Classes;
using InterfacesLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages.Member
{
    [Authorize]
    public class LikedEventsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public List<Event> EventList { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;

        public bool IsLoggedIn { get; set; }

        private readonly IEventService _eventService;

        public LikedEventsModel(IEventService _eventService)
        {
            this._eventService = _eventService;
        }
        public async Task OnGetAsync()
        {
            var totalItemCount = await _eventService.GetUserLikedEventsCountAsync(int.Parse(User.FindFirst("id").Value));
            TotalPages = (int)Math.Ceiling(totalItemCount / (double)PageSize);

            EventList = await _eventService.GetUserLikedEventsAsync(CurrentPage, PageSize, int.Parse(User.FindFirst("id").Value));
        }
        public IActionResult OnGetImage(int id)
        {
            var e = _eventService.GetEventById(id);
            if (e != null && e.Picture != null)
            {
                return File(e.Picture, "image/jpeg");
            }
            return NotFound();
        }
    }
}
