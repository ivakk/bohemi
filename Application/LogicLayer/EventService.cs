using Classes;
using DTOs;
using InterfacesDAL;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class EventService : IEventService
    {
        public readonly IEventDAL _eventDAL;

        public EventService(IEventDAL eventDAL)
        {
            this._eventDAL = eventDAL;
        }

        public bool CreateEvent(EventDTO newEvent)
        {
            if (newEvent == null)
            {
                return false;
            }
            else if (newEvent.Id == null || string.IsNullOrEmpty(newEvent.Title) || string.IsNullOrEmpty(newEvent.Description) || string.IsNullOrEmpty(newEvent.Day.ToString())
                 || string.IsNullOrEmpty(newEvent.Picture.ToString()))
            {
                return false;
            }
            else
            {
                return _eventDAL.CreateEventDAL(newEvent);
            }
        }

        public bool DeleteEvent(int id)
        {
            if (id < 0)
            {
                return false;
            }
            else
            {
                return _eventDAL.DeleteEventDAL(id);
            }
        }

        public List<Event> GetAllEvents()
        {
            return _eventDAL.GetAllEventsDAL();
        }

        public Event GetEventById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _eventDAL.GetEventByIdDAL(id);
            }
        }

        public bool UpdateEvent(EventDTO updateEvent)
        {
            if (updateEvent == null)
            {
                return false;
            }
            else if (updateEvent.Id == null || string.IsNullOrEmpty(updateEvent.Title) || string.IsNullOrEmpty(updateEvent.Description) || string.IsNullOrEmpty(updateEvent.Day.ToString())
                 || string.IsNullOrEmpty(updateEvent.Picture.ToString()))
            {
                return false;
            }
            else
            {
                return _eventDAL.UpdateEventDAL(updateEvent);
            }
        }
        public List<Event> GetEventsBySearch(string search)
        {
            List<Event> result = new List<Event>();
            foreach (Event Event in GetAllEvents())
            {
                if (Event.GetObjectString().Contains(search))
                {
                    result.Add(Event);
                }
            }
            return result;
        }

        public bool LikeEvent(LikedEvent likedEvent)
        {
            if (likedEvent == null)
            {
                return false;
            }
            else
            {
                return _eventDAL.LikeEventDAL(likedEvent);
            }
        }

        public bool RemoveFromLikedEvents(LikedEvent likedEvent)
        {
            if (likedEvent == null)
            {
                return false;
            }
            else
            {
                return _eventDAL.RemoveFromLikedEventsDAL(likedEvent);
            }
        }

        public bool IsEventLiked(LikedEvent likedEvent)
        {
            if (likedEvent == null)
            {
                return false;
            }
            else
            {
                return _eventDAL.IsEventLikedDAL(likedEvent);
            }
        }
        public async Task<List<Event>> GetPaginationEventsAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return await _eventDAL.GetPaginationEventsDALAsync(pageNumber, pageSize, searchTerm);
            }
            else
            {
                return await _eventDAL.GetPaginationEventsDALAsync(pageNumber, pageSize, "");
            }
        }
        public async Task<int> GetTotalEventsCountAsync(string? searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return await _eventDAL.GetTotalEventsCountDALAsync(searchTerm);
            }
            else
            {
                return await _eventDAL.GetTotalEventsCountDALAsync("");
            }
        }

        public List<Event> GetFirstEvents(int count)
        {
            if (count > 0)
            {
                return _eventDAL.GetFirstEventsDAL(count);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public List<LikedEvent> GetLikedEvents()
        {
            return _eventDAL.GetAllLikedEventsDAL();
        }

        public Task<List<Event>> GetUserLikedEventsAsync(int pageNumber, int pageSize, int userId)
        {
            if (pageNumber < 0 || pageSize < 0 || userId < 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _eventDAL.GetUserLikedEventsDALAsync(pageNumber, pageSize, userId);
            }
        }

        public async Task<int> GetUserLikedEventsCountAsync(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return await _eventDAL.GetUserLikedEventsCountDALAsync(userId);
            }
        }
    }
}
