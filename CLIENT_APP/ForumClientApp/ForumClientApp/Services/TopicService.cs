using Forum.Data.Models;
using ForumClientApp.Contracts;
using ForumClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForumClientApp.Services
{
    public class TopicService : ServiceBase, ITopicService
    {
        public TopicService(IHttpClientFactory httpClientFactory) : base (httpClientFactory, Clients.TopicClient)
        {
        }
        
        public List<TopicViewModel> GetTopics()
        {
            var client = _httpClientFactory.CreateClient("TopicClient");
            var responseMessage = client.GetAsync("api/Topic").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var topics = JsonConvert.DeserializeObject<List<TopicViewModel>>(responseData);
                return topics;
            }
            return new List<TopicViewModel>();
        }

        public TopicViewModel GetTopic(int id)
        {
            var client = _httpClientFactory.CreateClient("TopicClient");
            var responseMessage = client.GetAsync("api/Topic/"+id+"").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var topic = JsonConvert.DeserializeObject<TopicViewModel>(responseData);
                return topic;
            }
            return new TopicViewModel();
        }

        public List<SectionViewModel> CeateNewTopic(TopicViewModel topic)
        {
            Topic newTopic = new Topic();
            newTopic.Description = topic.Description;
            newTopic.SectionId = topic.SectionId;

            var client = _httpClientFactory.CreateClient("TopicClient");
            string stringData = JsonConvert.SerializeObject(topic);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            try
            {
                response = client.PostAsync("api/Topic", contentData).Result;
            }
            catch (Exception ex)
            {
                var postException = ex.Message;
            }
            string content = response.Content.ReadAsStringAsync().ToString();
            return new List<SectionViewModel>();
        }

        public List<SectionViewModel> DeleteTopic(int id)
        {

            HttpResponseMessage response = null;
            response = _client.DeleteAsync("api/Topic/" + id + "").Result;
            return new List<SectionViewModel>();
        }

        public List<SectionViewModel> UpdateTopic(int id, TopicViewModel topic)
        {
            string stringData = JsonConvert.SerializeObject(topic);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage responce = _client.PutAsync("api/Topic/" + id + "", contentData).Result;

            return new List<SectionViewModel>();
        }
    }
}
