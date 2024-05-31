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

        public Event GetEventByIdDAL(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEventDAL(EventDTO updateEvent)
        {
            throw new NotImplementedException();
        }
    }
}
