using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CommentsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Information { get; set; }
        public string Username { get; set; }

        public CommentsDTO(int id, int userId, int eventId, DateTime commentDate, string information)
        {
            Id = id;
            UserId = userId;
            EventId = eventId;
            CommentDate = commentDate;
            Information = information;
        }

        public CommentsDTO()
        {
        }
    }
}
