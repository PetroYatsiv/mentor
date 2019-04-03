using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ForumClientApp.Contracts;
using ForumClientApp.Models;
using Newtonsoft.Json;

namespace ForumClientApp.Services
{
    public class CommentsService : ServiceBase, ICommentService
    {
        public CommentsService(IHttpClientFactory httpClientFactory) : base (httpClientFactory, Clients.CommentClient)
        {
        }

        public List<CommentViewModel> CreateNewComment(CommentViewModel commentViewModel)
        {
            string stringData = JsonConvert.SerializeObject(commentViewModel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            try
            {
                response = _client.PostAsync("api/Comment", contentData).Result;
            }
            catch (Exception ex)
            {
                var postException = ex.Message;
            }
            string content = response.Content.ReadAsStringAsync().ToString();
            return new List<CommentViewModel>();
        }

        public List<CommentViewModel> DeleteComment(int commentId)
        {
            HttpResponseMessage response = null;
            response = _client.DeleteAsync("api/Comment/" + commentId + "").Result;
            return new List<CommentViewModel>();
        }

        public List<CommentViewModel> GetComments(int subTopicId)
        {
            throw new NotImplementedException();
        }

        public List<CommentViewModel> UpdateComment(int id, CommentViewModel comment)
        {
            string stringData = JsonConvert.SerializeObject(comment);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage responce = _client.PutAsync("api/Comment/" + id + "", contentData).Result;

            return new List<CommentViewModel>();
        }
    }
}
