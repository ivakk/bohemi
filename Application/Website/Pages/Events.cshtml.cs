using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Classes;
using InterfacesLL;
using LogicLayer;
using Microsoft.Extensions.Logging;

namespace Website.Pages
{
    public class EventsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public List<Event> EventList { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public string PreviousSearchTerm { get; set; }

        public bool IsLoggedIn { get; set; }

        private readonly IEventService _eventService;

        public EventsModel (IEventService _eventService)
        {
            this._eventService = _eventService;
        }
        public async Task OnGetAsync()
        {
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
            }

            if (!string.IsNullOrWhiteSpace(PreviousSearchTerm) && !PreviousSearchTerm.Equals(SearchTerm))
            {
                CurrentPage = 1; 
            }

            var totalItemCount = await _eventService.GetTotalEventsCountAsync(SearchTerm);
            TotalPages = (int)Math.Ceiling(totalItemCount / (double)PageSize);

            EventList = await _eventService.GetPaginationEventsAsync(CurrentPage, PageSize, SearchTerm);

            PreviousSearchTerm = SearchTerm;
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
        public async Task<IActionResult> OnPost(int currentPage = 1)
        {
            CurrentPage = currentPage;
            var totalItemCount = await _eventService.GetTotalEventsCountAsync(SearchTerm);
            TotalPages = (int)Math.Ceiling(totalItemCount / (double)PageSize);

            EventList = await _eventService.GetPaginationEventsAsync(CurrentPage, PageSize, SearchTerm);

            return Page();
        }
    }
}
