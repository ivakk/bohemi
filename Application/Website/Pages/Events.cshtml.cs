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
        [BindProperty]
        public List<Event> EventList { get; set; }
        public bool IsLoggedIn { get; set; }

        private readonly IEventService _eventService;

        public EventsModel (IEventService _eventService)
        {
            this._eventService = _eventService;
        }
        public void OnGet()
        {
            EventList = _eventService.GetAllEvents();
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
            }
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
