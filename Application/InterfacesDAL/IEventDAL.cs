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
    }
}
