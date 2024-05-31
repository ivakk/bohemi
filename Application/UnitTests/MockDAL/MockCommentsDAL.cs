using Classes;
using InterfacesDAL;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockDAL
{
    public class MockCommentsDAL : ICommentsDAL
    {
        public List<Comments> comments = new List<Comments>();
        private int nextId = 1;  // Simulating auto-increment ID

        public Comments GetCommentByIdDAL(int id)
        {
            return comments.FirstOrDefault(c => c.Id == id);
        }

        public List<Comments> GetAllCommentsDAL(int eventId)
        {
            return comments.Where(c => c.EventId == eventId).ToList();
        }

        public bool CreateCommentDAL(CommentsDTO newComment)
        {
            try
            {
                newComment.Id = nextId++;
                comments.Add(new Comments(newComment.Id, newComment.UserId, newComment.EventId, newComment.CommentDate, newComment.Information));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCommentDAL(int id)
        {
            var comment = GetCommentByIdDAL(id);
            if (comment != null)
            {
                comments.Remove(comment);
                return true;
            }
            return false;
        }

        public string GetCommentUserDAL(int id)
        {
            //var comment = GetCommentByIdDAL(id);
            //return comment?..Username; 
            throw new NotImplementedException();
        }
    }
}
