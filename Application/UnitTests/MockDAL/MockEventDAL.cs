using Classes;
using DTOs;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockDAL
{
    public class MockEventDAL : IEventDAL
    {
        public List<Event> events = new List<Event>();

        public MockEventDAL()
        {
            // Initialize with some dummy data
            events.Add(new Event(1, "Title1", "Description1", new DateTime(2023, 05, 15), null));
            events.Add(new Event(2, "Title2", "Description2", new DateTime(2023, 06, 15), null));
            events.Add(new Event(3, "Title3", "Description3", new DateTime(2023, 07, 15), null));
        }

        public bool CreateEventDAL(EventDTO newEvent)
        {
            events.Add(new Event(events.Max(e => e.Id) + 1, newEvent.Title, newEvent.Description, newEvent.Day, newEvent.Picture));
            return true;
        }

        public Event GetEventByIdDAL(int id)
        {
            return events.FirstOrDefault(e => e.Id == id);
        }

        public bool DeleteEventDAL(int id)
        {
            var eventToRemove = events.FirstOrDefault(e => e.Id == id);
            if (eventToRemove != null)
            {
                events.Remove(eventToRemove);
                return true;
            }
            return false;
        }

        public List<Event> GetAllEventsDAL()
        {
            return new List<Event>(events);
        }

        public bool UpdateEventDAL(EventDTO updateEvent)
        {
            var eventToUpdate = events.FirstOrDefault(e => e.Id == updateEvent.Id);
            if (eventToUpdate != null)
            {
                events.Remove(GetEventByIdDAL(eventToUpdate.Id));
                events.Add(new Event(eventToUpdate.Id, updateEvent.Title, updateEvent.Description, updateEvent.Day, updateEvent.Picture));
                return true;
            }
            return false;
        }

        public Task<List<Event>> GetPaginationEventsDALAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalEventsCountDALAsync(string? searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetUserLikedEventsDALAsync(int pageNumber, int pageSize, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserLikedEventsCountDALAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public bool LikeEventDAL(LikedEvent likedEvent)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromLikedEventsDAL(LikedEvent likedEvent)
        {
            throw new NotImplementedException();
        }

        public bool IsEventLikedDAL(LikedEvent likedEvent)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetFirstEventsDAL(int count)
        {
            throw new NotImplementedException();
        }

        public List<LikedEvent> GetAllLikedEventsDAL()
        {
            throw new NotImplementedException();
        }
    }
}
