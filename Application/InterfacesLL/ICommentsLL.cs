using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface ICommentsLL
    {
        Comments GetCommentById(int id);
        List<Comments> GetAllComments(int eventId);
        bool CreateComment(Comments comment);
        bool DeleteComment(int id);
        string GetCommentUser(int id);
    }
}
