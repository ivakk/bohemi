using Classes;
using DTOs;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockDAL;

namespace UnitTests
{
    public class CommentsTests
    {
        [Fact]
        public void CreateCommentDAL_AddsComment_ReturnsTrue()
        {
            // Arrange
            var newComment = new CommentsDTO(0, 1, 1, DateTime.Now, "This is a test comment", "testuser");

            MockCommentsDAL _mockCommentsDAL = new MockCommentsDAL();
            CommentsService _commentsLL = new CommentsService(_mockCommentsDAL);

            // Act
            bool result = _commentsLL.CreateComment(newComment);

            // Assert
            Assert.True(result);
            Assert.NotEmpty(_commentsLL.GetAllComments(1));
        }

        [Fact]
        public void GetCommentById_ReturnsComment_WhenIdIsValid()
        {
            // Arrange
            var newComment = new CommentsDTO(0, 1, 1, DateTime.Now, "This is another test comment", "testuser");

            MockCommentsDAL _mockCommentsDAL = new MockCommentsDAL();
            CommentsService _commentsLL = new CommentsService(_mockCommentsDAL);

            _commentsLL.CreateComment(newComment);
            int commentId = _mockCommentsDAL.comments.Last().Id;

            // Act
            var comment = _commentsLL.GetCommentById(commentId);

            // Assert
            Assert.NotNull(comment);
            Assert.Equal("This is another test comment", comment.Information);
        }

        [Fact]
        public void DeleteComment_RemovesComment_WhenIdIsValid()
        {
            // Arrange
            var newComment = new CommentsDTO(0, 1, 1, DateTime.Now, "This is yet another test comment", "testuser");

            MockCommentsDAL _mockCommentsDAL = new MockCommentsDAL();
            CommentsService _commentsLL = new CommentsService(_mockCommentsDAL);

            _commentsLL.CreateComment(newComment);
            int commentId = _mockCommentsDAL.comments.Last().Id;

            // Act
            bool result = _commentsLL.DeleteComment(commentId);

            // Assert
            Assert.True(result);
            Assert.Null(_commentsLL.GetCommentById(commentId));
        }

        [Fact]
        public void GetAllComments_ReturnsAllCommentsForEvent()
        {
            // Arrange
            var newComment1 = new CommentsDTO(0, 1, 1, DateTime.Now, "Comment one for event", "testuser");
            var newComment2 = new CommentsDTO(0, 2, 1, DateTime.Now, "Comment two for event", "testuser");

            MockCommentsDAL _mockCommentsDAL = new MockCommentsDAL();
            CommentsService _commentsLL = new CommentsService(_mockCommentsDAL);

            _commentsLL.CreateComment(newComment1);
            _commentsLL.CreateComment(newComment2);

            // Act
            var allComments = _commentsLL.GetAllComments(1);

            // Assert
            Assert.Equal(2, allComments.Count);
        }
    }
}
