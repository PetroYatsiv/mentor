using Forum.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForumClientApp.Services
{
    public class TopicService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TopicService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public TopicService()
        {
        }

        public List<Topic> GetTopics()
        {
            var client = _httpClientFactory.CreateClient("TopicClient");
            var responseMessage = client.GetAsync("api/Topic").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var topics = JsonConvert.DeserializeObject<List<Topic>>(responseData);
                return topics;
            }
            return new List<Topic>();
        }
        public Topic GetTopic(int id)
        {
            var client = _httpClientFactory.CreateClient("TopicClient");
            var responseMessage = client.GetAsync("api/Topic/"+id+"").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var topic = JsonConvert.DeserializeObject<Topic>(responseData);
                return topic;
            }
            return new Topic();
        }
    }
}
