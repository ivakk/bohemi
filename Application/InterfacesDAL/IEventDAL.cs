using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDAL
{
    public interface IEventDAL
    {
        bool CreateEventDAL(EventDTO newEvent);
        Event GetEventByIdDAL(int id);
        bool DeleteEventDAL(int id);
        List<Event> GetAllEventsDAL();
        bool UpdateEventDAL(EventDTO updateEvent);
        bool LikeEventDAL(LikedEvent likedEvent);
        bool RemoveFromLikedEventsDAL(LikedEvent likedEvent);
        bool IsEventLikedDAL(LikedEvent likedEvent);
        Task<List<Event>> GetPaginationEventsDALAsync(int pageNumber, int pageSize, string? searchTerm);
        Task<int> GetTotalEventsCountDALAsync(string? searchTerm);
        List<Event> GetFirstEventsDAL(int count);
        List<LikedEvent> GetAllLikedEventsDAL();
        Task<List<Event>> GetUserLikedEventsDALAsync(int pageNumber, int pageSize, int userId);
        Task<int> GetUserLikedEventsCountDALAsync(int userId);
    }
}
