using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IEventService
    {
        bool CreateEvent(EventDTO newEvent);
        Event GetEventById(int id);
        bool DeleteEvent(int id);
        List<Event> GetAllEvents();
        bool UpdateEvent(EventDTO updateEvent);
        List<Event> GetEventsBySearch(string search);
        bool LikeEvent(LikedEvent likedEvent);
        bool RemoveFromLikedEvents(LikedEvent likedEvent);
        bool IsEventLiked(LikedEvent likedEvent);
        Task<List<Event>> GetPaginationEventsAsync(int pageNumber, int pageSize, string? searchTerm);
        Task<int> GetTotalEventsCountAsync(string? searchTerm);
        List<Event> GetFirstEvents(int count);
        List<LikedEvent> GetLikedEvents();
    }
}
