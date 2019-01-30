using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ForumClientApp.Models;
using Newtonsoft.Json;
using Forum.Data.Models;

namespace ForumClientApp.Services
{
    public interface ISectionService
    {
        List<SectionViewModel> GetSections();
        List<SectionViewModel> CreateNewSection(SectionViewModel sectionViewModel);
        List<SectionViewModel> DeleteSection(int id);
    }

    public class SectionService : ISectionService
    {
        private readonly HttpClient client;
        private readonly IHttpClientFactory _httpClientFactory;
        public SectionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            client = _httpClientFactory.CreateClient(Clients.SectionClient);
        }
        public SectionService()
        {
        }

        public List<SectionViewModel> GetSections()
        {
            var responseMessage = client.GetAsync("api/Section").Result;

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
                response = client.PostAsync("api/Section", contentData).Result;
            }
            catch (Exception ex)
            {
                var postException = ex.Message;
            }

            string content = response.Content.ReadAsStringAsync().ToString();

            return new List<SectionViewModel>();
        }

        public void UpdateSection(int sectionId, SectionViewModel section)
        {

        }

        public List<SectionViewModel> DeleteSection (int sectionId)
        {
            HttpResponseMessage response = null;
            response = client.DeleteAsync("api/Section/"+sectionId+"").Result;
            return new List<SectionViewModel>();
        }
    }
}
