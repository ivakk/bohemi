using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDAL
{
    public interface ICommentsDAL
    {
        Comments GetCommentByIdDAL(int id);
        List<Comments> GetAllCommentsDAL(int eventId);
        bool CreateCommentDAL(CommentsDTO comment);
        bool DeleteCommentDAL(int id);
        string GetCommentUserDAL(int id);
    }
}
