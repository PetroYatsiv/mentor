using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ForumClientApp.Contracts;
using ForumClientApp.Models;

namespace ForumClientApp.Services
{
    public class SubTopicService : ServiceBase, ISubtopicService
    {
        public SubTopicService(IHttpClientFactory httpClientFactory) :base (httpClientFactory,Clients.SubTopicClient)
        {

        }
        public List<SubTopicViewModel> CreateNewSubTopic(SubTopicViewModel sectionViewModel)
        {
            //    string stringData = JsonConvert.SerializeObject(section);
            //    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            //    HttpResponseMessage response = null;
            //    try
            //    {
            //        response = _client.PostAsync("api/Section", contentData).Result;
            //    }
            //    catch (Exception ex)
            //    {
            //        var postException = ex.Message;
            //    }
            //    string content = response.Content.ReadAsStringAsync().ToString();
            return new List<SubTopicViewModel>();
        }

        public List<SubTopicViewModel> DeleteSubTopic(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubTopicViewModel> GetSubTopics(int topicId)
        {
            throw new NotImplementedException();
        }

        public List<SubTopicViewModel> UpdateSubTopic(int id, SubTopicViewModel section)
        {
            throw new NotImplementedException();
        }
    }
}
