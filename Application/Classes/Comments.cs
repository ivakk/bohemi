using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Comments
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int EventId { get; private set; }
        public DateTime CommentDate { get; private set; }
        public string Information { get; private set; }
        public string Username { get; private set; }

        public Comments(int id, int userId, int eventId, DateTime commentDate, string information, string username)
        {
            Id = id;
            UserId = userId;
            EventId = eventId;
            CommentDate = commentDate;
            Information = information;
            Username = username;
        }

        public Comments()
        {
        }
    }
}
