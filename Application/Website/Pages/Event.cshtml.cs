using Classes;
using InterfacesLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Website.Pages
{
    public class EventModel : PageModel
    {
        public Event? Event { get; set; }
        public string LikedButtonText => IsEventLiked ? "Liked ❤" : "Like ❤";
        public bool IsEventLiked { get; private set; }
        public bool IsLoggedIn { get; set; }

        private readonly IEventService _eventService;

        public EventModel(IEventService eventService)
        {
            _eventService = eventService;
        }
        public void OnGet(int id)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    IsEventLiked = _eventService.IsEventLiked(new LikedEvent(int.Parse(User.FindFirst("id").Value), id));
                    IsLoggedIn = true;
                }
                Event = _eventService.GetEventById(id);
            }
            catch (ArgumentNullException)
            {
                Response.Redirect("/404");
            }
            catch (Exception)
            {

            }
        }
        public IActionResult OnGetImage(int id)
        {
            Event = _eventService.GetEventById(id);
            if (Event != null && Event.Picture != null)
            {
                return File(Event.Picture, "image/jpeg");
            }
            return NotFound();
        }
        public IActionResult OnPostToggleLiked(int eventId)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    IsEventLiked = _eventService.IsEventLiked(new LikedEvent(int.Parse(User.FindFirst("id").Value), eventId));
                    if (IsEventLiked)
                    {
                        _eventService.RemoveFromLikedEvents(new LikedEvent(int.Parse(User.FindFirst("id").Value), eventId));
                    }
                    else
                    {
                        _eventService.LikeEvent(new LikedEvent(int.Parse(User.FindFirst("id").Value), eventId));
                    }
                    IsEventLiked = !IsEventLiked;
                    return RedirectToPage(new { id = eventId });
                }
                else
                {
                    return RedirectToPage("/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return RedirectToPage(new { id = eventId });
            }
        }
    }
}
