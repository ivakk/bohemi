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
        public bool CreateEventDAL(EventDTO newEvent)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEventDAL(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEventsDAL()
        {
            throw new NotImplementedException();
        }

        public List<LikedEvent> GetAllLikedEventsDAL()
        {
            throw new NotImplementedException();
        }

        public Event GetEventByIdDAL(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetFirstEventsDAL(int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetPaginationEventsDALAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalEventsCountDALAsync(string? searchTerm)
        {
            throw new NotImplementedException();
        }

        public bool IsEventLikedDAL(LikedEvent likedEvent)
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

        public bool UpdateEventDAL(EventDTO updateEvent)
        {
            throw new NotImplementedException();
        }
    }
}
