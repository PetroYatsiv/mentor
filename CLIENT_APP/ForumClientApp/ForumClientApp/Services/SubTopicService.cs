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
    public class SubTopicService : ServiceBase, ISubtopicService
    {
        public SubTopicService(IHttpClientFactory httpClientFactory) :base (httpClientFactory,Clients.SubTopicClient)
        {

        }
        public List<SubTopicViewModel> CreateNewSubTopic(SubTopicViewModel subTopicViewModel)
        {
                string stringData = JsonConvert.SerializeObject(subTopicViewModel);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                try
                {
                    response = _client.PostAsync("api/SubTopic", contentData).Result;
                }
                catch (Exception ex)
                {
                    var postException = ex.Message;
                }
                string content = response.Content.ReadAsStringAsync().ToString();
            return new List<SubTopicViewModel>();
        }

        public SubTopicViewModel GetSubTopic(int id)
        {
            var responseMessage = _client.GetAsync("api/SubTopic/"+id+"").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var subTopic = JsonConvert.DeserializeObject<SubTopicViewModel>(responseData);
                return subTopic;
            }
            return new SubTopicViewModel();
        }

        public List<SubTopicViewModel> UpdateSubTopic(int id, SubTopicViewModel subTopic)
        {
            string stringData = JsonConvert.SerializeObject(subTopic);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage responce = _client.PutAsync("api/SubTopic/" + id + "", contentData).Result;

            return new List<SubTopicViewModel>();
        }

        public List<SubTopicViewModel> DeleteSubTopic(int id)
        {
            HttpResponseMessage response = null;
            response = _client.DeleteAsync("api/SubTopic/" + id + "").Result;
            return new List<SubTopicViewModel>();
        }
    }
}
