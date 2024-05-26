using Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class CommentsLL : ICommentsLL
    {
        public bool CreateComment(Comments comment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comments> GetAllComments(int eventId)
        {
            throw new NotImplementedException();
        }

        public Comments GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetCommentUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
