using Classes;
using InterfacesDAL;
using DTOs;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LogicLayer
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsDAL _commentsDAL;

        public CommentsService(ICommentsDAL commentsDAL)
        {
            this._commentsDAL = commentsDAL;
        }
        public bool CreateComment(CommentsDTO comment)
        {
            if (comment == null)
            {
                return false;
            }
            else if (comment.Id == null || string.IsNullOrEmpty(comment.UserId.ToString()) || string.IsNullOrEmpty(comment.EventId.ToString()) || string.IsNullOrEmpty(comment.CommentDate.ToString())
                 || string.IsNullOrEmpty(comment.Information.ToString()))
            {
                return false;
            }
            else
            {
                return _commentsDAL.CreateCommentDAL(comment);
            }
        }

        public bool DeleteComment(int id)
        {
            if (id < 0)
            {
                return false;
            }
            else
            {
                return _commentsDAL.DeleteCommentDAL(id);
            }
        }

        public List<Comments> GetAllComments(int eventId)
        {
            if (eventId < 0 || eventId == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _commentsDAL.GetAllCommentsDAL(eventId);
            }
        }

        public Comments GetCommentById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _commentsDAL.GetCommentByIdDAL(id);
            }
        }

        public string GetCommentUser(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return _commentsDAL.GetCommentUserDAL(id);
            }
        }
        public bool CanUserDeleteComment(int userId, string userRole, int commenterId)
        {
            if (userId < 0 || string.IsNullOrWhiteSpace(userRole) || commenterId < 0)
            {
                throw new ArgumentNullException();
            }

            if (userId == commenterId || userRole == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
