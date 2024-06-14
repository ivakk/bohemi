using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface ICommentsService
    {
        Comments GetCommentById(int id);
        List<Comments> GetAllComments(int eventId);
        bool CreateComment(CommentsDTO comment);
        bool DeleteComment(int id);
        bool CanUserDeleteComment(int userId, string userRole, int commenterId);
    }
}
