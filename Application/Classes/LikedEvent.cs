using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class LikedEvent
    {
        public int UserId { get; set; }
        public int EventId { get; set; }

        public LikedEvent(int userId, int eventId)
        {
            UserId = userId;
            EventId = eventId;
        }
    }
}
