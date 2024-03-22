using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Reservation
    {
        public int Id { get; }
        public string Person { get; set; }
        public int EventId { get; set; }
        public string Seats { get; set; }

        public Reservation(int id, string person, int eventId, string seats) 
        {
            Id = id;
            Person = person;
            EventId = eventId;
            Seats = seats;
        }
    }
}
