using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ForumClientApp.Models;
using Newtonsoft.Json;
using Forum.Data.Models;
using ForumClientApp.Contracts;

namespace ForumClientApp.Services
{
    public class SectionService :  ServiceBase, ISectionService
    {
        public SectionService(IHttpClientFactory clientFactory) : base(clientFactory, Clients.SectionClient)
        {
        }
        public List<SectionViewModel> GetSections()
        {
            var responseMessage = _client.GetAsync("api/Section").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var sections = JsonConvert.DeserializeObject<List<SectionViewModel>>(responseData);
                return sections;
            }
            return new List<SectionViewModel>();
        }

        public List<SectionViewModel> CreateNewSection(SectionViewModel section)
        {
            string stringData = JsonConvert.SerializeObject(section);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            try
            {
                response = _client.PostAsync("api/Section", contentData).Result;
            }
            catch (Exception ex)
            {
                var postException = ex.Message;
            }
            //string content = response.Content.ReadAsStringAsync().ToString();
            return new List<SectionViewModel>();
        }

        public List<SectionViewModel> UpdateSection(int sectionId, SectionViewModel section)
        {
            string stringData = JsonConvert.SerializeObject(section);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            try
            {
                _client.PutAsync("api/Section/" + sectionId + "", contentData);
            }
            catch (Exception ex)
            {
                var putException = ex.Message;
            }
            return new List<SectionViewModel>();
        }

        public List<SectionViewModel> DeleteSection (int sectionId)
        {
            HttpResponseMessage response = null;
            response = _client.DeleteAsync("api/Section/"+sectionId+"").Result;
            return new List<SectionViewModel>();
        }
    }
}
