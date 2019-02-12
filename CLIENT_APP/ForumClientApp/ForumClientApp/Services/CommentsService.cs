using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumClientApp.Contracts;
using ForumClientApp.Models;

namespace ForumClientApp.Services
{
    public class CommentsService : ICommentService
    {
        public List<CommentViewModel> CreateNewComment(CommentViewModel commentViewModel)
        {
            throw new NotImplementedException();
        }

        public List<CommentViewModel> DeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public List<CommentViewModel> GetComments(int subTopicId)
        {
            throw new NotImplementedException();
        }

        public List<CommentViewModel> UpdateSubTopic(int id, CommentViewModel comment)
        {
            throw new NotImplementedException();
        }
    }
}
