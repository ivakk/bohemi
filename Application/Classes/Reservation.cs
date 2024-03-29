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
        public string Person { get; private set; }
        public int EventId { get; private set; }
        public string Seats { get; private set; }
        public int PhoneNumber { get; private set; }

        public Reservation(int id, string person, int eventId, string seats, int phoneNumber) 
        {
            Id = id;
            Person = person;
            EventId = eventId;
            Seats = seats;
            PhoneNumber = phoneNumber;
        }
    }
}
