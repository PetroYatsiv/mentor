using ForumClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Contracts
{
   public interface ICommentService
    {
        List<CommentViewModel> GetComments(int subTopicId);
        List<CommentViewModel> CreateNewComment(CommentViewModel commentViewModel);
        List<CommentViewModel> DeleteComment(int commentId);
        List<CommentViewModel> UpdateSubTopic(int id, CommentViewModel comment);
    }
}
