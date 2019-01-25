using ForumClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForumClientApp.Services
{
    public interface ITopicService
    {
        List<TopicViewModel> GetTopics();
        TopicViewModel GetTopic(int id);
    }

    public class TopicService :ITopicService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TopicService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public TopicService()
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

        public void CeateTopic(TopicViewModel topic)
        {
            var client = _httpClientFactory.CreateClient("TopicClient");
            string stringData = JsonConvert.SerializeObject(topic);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            var responseMessage = client.PostAsync("api/Topic/", contentData).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var newTopic = JsonConvert.DeserializeObject<TopicViewModel>(responseData);
            }
        }

    }
}
