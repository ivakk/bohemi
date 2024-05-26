using Classes;
using DTOs;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class EventLL : IEventLL
    {
        public bool CreateEvent(EventDTO newEvent)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Event GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(EventDTO updateEvent)
        {
            throw new NotImplementedException();
        }
    }
}
