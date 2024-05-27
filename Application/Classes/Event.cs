using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Event
    {
        public int Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Day { get; private set; }
        public byte[] Picture { get; private set; }

        public Event(int id, string title, string description, DateTime day, byte[] picture)
        {
            Id = id;
            Title = title;
            Description = description;
            Day = day;
            Picture = picture;
        }
        public string GetObjectString()
        {
            return Id.ToString() + Title + Day.ToString();
        }
    }
}
