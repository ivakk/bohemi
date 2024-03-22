using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Event
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Day { get; set; }
        public byte[] Picture { get; set; }

        public Event(int id, string title, string description, DateTime day, byte[] picture)
        {
            Id = id;
            Title = title;
            Description = description;
            Day = day;
            Picture = picture;
        }
    }
}
