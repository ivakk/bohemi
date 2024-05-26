using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IEventLL
    {
        bool CreateEvent(EventDTO newEvent);
        Event GetEventById(int id);
        bool DeleteEvent(int id);
        List<Event> GetAllEvents();
        bool UpdateEvent(EventDTO updateEvent);
    }
}
