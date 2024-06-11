using Classes;
using InterfacesLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using DTOs;

namespace Website.Pages
{
    public class EventModel : PageModel
    {
        public Event? Event { get; set; }
        public List<Comments> Comments { get; set; }
        [BindProperty]
        public string CommentLeft { get; set; }
        public string LikedButtonText => IsEventLiked ? "Liked ❤" : "Like 🤍";
        public bool IsEventLiked { get; private set; }
        public bool IsLoggedIn { get; set; }

        private readonly IEventService _eventService;
        private readonly ICommentsService _commentsService;
        private readonly IUserService _userService;
        private readonly IReportService _reportService;

        public EventModel(IEventService eventService, ICommentsService commentsService, IUserService userService, IReportService reportService)
        {
            _eventService = eventService;
            _commentsService = commentsService;
            _userService = userService;
            _reportService = reportService;
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
                Comments = _commentsService.GetAllComments(id);
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
        public IActionResult OnPostComment(int id)
        {
            //Checks whether anyone is logged inm
            if (User.FindFirst("id") != null)
            {
                try
                {
                    _commentsService.CreateComment(new CommentsDTO(0, int.Parse(User.FindFirst("id").Value), id, DateTime.Now, CommentLeft, _userService.GetUserById(int.Parse(User.FindFirst("id").Value)).Username));

                    CommentLeft = ""; // Reset the comment box

                    // Re-fetch event data and other necessary data
                    Event = _eventService.GetEventById(id);
                    Comments = _commentsService.GetAllComments(id);

                    return RedirectToPage(new { id = id });
                }
                catch (Exception ex)
                {
                    ViewData["Error"] = ex.Message;
                    return RedirectToPage(new { id = id });
                }
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }
        public bool CanDeleteComment(int id)
        {
            //Checks whether anyone is logged in
            if (User.FindFirst("id") != null)
            {
                try
                {
                    return _commentsService.CanUserDeleteComment(int.Parse(User.FindFirst("id").Value), _userService.GetUserById(int.Parse(User.FindFirst("id").Value)).Role, id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            }
            return false;
        }
        public IActionResult OnPostDeleteComment(int id, int commentId)
        {
            try
            {
                // Authorization check: Ensure the user is allowed to delete the comment
                var comment = _commentsService.GetCommentById(commentId);
                if (comment != null && CanDeleteComment(comment.UserId))
                {
                    _commentsService.DeleteComment(commentId);

                    // Re-fetch event data and other necessary data
                    Event = _eventService.GetEventById(id);
                    Comments = _commentsService.GetAllComments(id);

                    return RedirectToPage(new { id = id });
                }

                // If the user is not authorized to delete, handle accordingly
                // Redirect to the same page with an error message or a status
                ViewData["Error"] = "You are not authorized to delete this comment.";

                Event = _eventService.GetEventById(id);
                Comments = _commentsService.GetAllComments(id);

                return RedirectToPage(new { id = id });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Event = _eventService.GetEventById(id);
                Comments = _commentsService.GetAllComments(id);
                return RedirectToPage(new { id = id });
            }
        }
        public IActionResult OnPostReportComment(int id, int commentId)
        {
            try
            {
                var comment = _commentsService.GetCommentById(commentId);
                if (comment != null)
                {
                    _reportService.CreateReport(new ReportDTO(0, commentId, int.Parse(User.FindFirst("id").Value)));

                    // Re-fetch event data and other necessary data
                    Event = _eventService.GetEventById(id);
                    Comments = _commentsService.GetAllComments(id);

                    return RedirectToPage(new { id = id });
                }

                Event = _eventService.GetEventById(id);
                Comments = _commentsService.GetAllComments(id);

                return RedirectToPage(new { id = id });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Event = _eventService.GetEventById(id);
                Comments = _commentsService.GetAllComments(id);
                return RedirectToPage(new { id = id });
            }
        }
    }
}
