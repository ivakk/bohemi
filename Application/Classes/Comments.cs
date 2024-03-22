using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Comments
    {
        public int Id { get; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Information { get; set; }
        public string Username { get; set; }

        public Comments(int id, int userId, int eventId, DateTime commentDate, string information)
        {
            Id = id;
            UserId = userId;
            EventId = eventId;
            CommentDate = commentDate;
            Information = information;
        }

        public Comments()
        {
        }
    }
}
